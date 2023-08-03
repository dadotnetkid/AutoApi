using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoApi.Core.Services;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace AutoApi.Core.Extensions
{
    public static class AutoRegisterServicesExtension
    {
        public static IServiceCollection AddAutoService(this IServiceCollection services)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(c => c.GetTypes());
            types = types.Where(c => c.BaseType == typeof(ApplicationService));
            foreach (var i in types)
            {
                var _ = i.GetInterfaces().FirstOrDefault();
                services.AddScoped(_, i);
            }

            return services;
        }

    }
}
