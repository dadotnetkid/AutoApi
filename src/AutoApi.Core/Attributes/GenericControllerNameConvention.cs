using AutoApi.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AutoApi.Core.Attributes
{
    public class GenericControllerNameConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.BaseType == typeof(ApplicationService))
            {
                var controllerName = controller.ControllerName.Replace("Service", "");
                controller.ControllerName = $"{controllerName}Controller";
                var actions = controller.Actions.ToList();
                controller.Actions.Clear();
                foreach (var i in controller.ControllerType.DeclaredMethods)
                {
                    var obj = GetHttpAttribute(i);
                    var model = new ActionModel(i, obj)
                    {
                        ActionName = $"{i.Name}",
                        Controller = controller,
                    };


                    SetParameter(model.Parameters, i);

                    model.Selectors.Add(new SelectorModel()
                    {
                        ActionConstraints =
                        {
                            new HttpMethodActionConstraint(new []{GetHttpMethod(i)})
                        },
                        EndpointMetadata =
                        {
                            obj,
                        }
                    });
                    controller.Actions.Add(model);
                }

                if (controller.Selectors.Any())
                {
                    var currentSelector = controller.Selectors[0];
                    currentSelector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute($"/{controllerName}"));
                }
                else
                {
                    controller.Selectors.Add(new SelectorModel
                    {
                        AttributeRouteModel = new AttributeRouteModel(new RouteAttribute($"/{controllerName}"))
                    });
                }
            }
        }

        private void SetParameter(IList<ParameterModel> modelParameters, MethodInfo methodInfo)
        {
            foreach (var parameter in methodInfo.GetParameters())
            {
                var param = GetParameter(parameter, methodInfo);
                modelParameters.Add(param);
            }
        }

        private ParameterModel GetParameter(ParameterInfo parameter, MethodInfo method)
        {
            var attributes = new List<object>();

            if (GetHttpMethod(method) != "GET")
            {
                attributes.Add(new FromBodyAttribute()
                {
                });
            }
            var model = new ParameterModel(parameter, attributes)
            {
                ParameterName = parameter.Name,
                Action = new ActionModel(method, new[] { GetHttpAttribute(method) }),
                BindingInfo = new BindingInfo()
                {
                    BindingSource = new BindingSource("Body", "Body", true, true)
                }
            };
            return model;
        }

        private IReadOnlyList<object> GetHttpAttribute(MethodInfo methodInfo)
        {
            var attribute = new List<object> { new HttpGetAttribute($"/{methodInfo.Name}")
                {
                    Name= methodInfo.Name,
                }
            };
            if (methodInfo.Name.Contains("get", StringComparison.CurrentCultureIgnoreCase))
            {
                attribute = new List<object>
                {
                    new HttpGetAttribute($"/{methodInfo.Name}")
                    {
                        Name = methodInfo.Name,
                    }
                };
            }
            if (Post.Any(c => methodInfo.Name.Contains(c, StringComparison.CurrentCultureIgnoreCase)))
            {
                attribute = new List<object> { new HttpPostAttribute($"/{methodInfo.Name}")
                {
                    Name= methodInfo.Name,
                }  };
            }
            if (Delete.Any(c => methodInfo.Name.Contains(c, StringComparison.CurrentCultureIgnoreCase)))
            {
                attribute = new List<object> { new HttpDeleteAttribute($"/{methodInfo.Name}")
                {
                    Name= methodInfo.Name,
                }  };
            }
            if (Put.Any(c => methodInfo.Name.Contains(c, StringComparison.CurrentCultureIgnoreCase)))
            {
                attribute = new List<object> { new HttpPutAttribute($"/{methodInfo.Name}")
                {
                    Name= methodInfo.Name,
                }  };
            }
            return attribute;
        }
        private string GetHttpMethod(MethodInfo methodInfo)
        {
            var attribute = "GET";
            if (Put.Any(c => methodInfo.Name.Contains(c, StringComparison.CurrentCultureIgnoreCase)))
            {
                attribute = "PUT";
            }
            if (Delete.Any(c => methodInfo.Name.Contains(c, StringComparison.CurrentCultureIgnoreCase)))
            {
                attribute = "Delete";
            }
            if (Post.Any(c => methodInfo.Name.Contains(c, StringComparison.CurrentCultureIgnoreCase)))
            {
                attribute = "Post";
            }

            return attribute;
        }

        private List<string> Put => new() { "patch", "update", "put", "edit", "modify" };
        private List<string> Delete => new() { "delete", "remove" };
        private List<string> Post => new() { "insert", "post", "add", "new" };
    }
}
