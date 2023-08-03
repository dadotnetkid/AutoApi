using System.Reflection;
using AutoApi.Core.Services;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace AutoApi.Core.Providers
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {

        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var types = parts.Where(c => c.GetType() == typeof(AssemblyPart))
                .Where(c => ((AssemblyPart)c).Types.Any(t => t.BaseType == typeof(ApplicationService)))
                .SelectMany(c => ((AssemblyPart)c).Types)
                .Where(c => c.BaseType == typeof(ApplicationService));
           
            foreach (var i in types)
            {
                feature.Controllers.Add(i.GetTypeInfo());
            }

        }
    }
}
