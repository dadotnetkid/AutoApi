using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoApi.Core.Attributes;
using AutoApi.Core.Providers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace AutoApi.Core.Extensions
{
    public static class AutoApiExtension
    {

        public static IServiceCollection AddAutoApi(this IServiceCollection services)
        {
            services.AddMvc(c =>
                {
                    c.Conventions.Add(new GenericControllerNameConvention());
                })
                .ConfigureApplicationPartManager(c =>
                {
                    c.FeatureProviders.Add(new GenericControllerFeatureProvider());
                });

            return services;
        }

    }
}
