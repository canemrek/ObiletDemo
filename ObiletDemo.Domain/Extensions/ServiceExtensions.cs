using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ObiletDemo.Domain.CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObiletDemo.Domain.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddMyOptions(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<ObiletServiceInfo>(configuration.GetSection("ObiletServiceInfo"));
        }
        public static IServiceCollection AddMySettings(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var obiletServiceInfo = serviceProvider.GetRequiredService<Microsoft.Extensions.Options.IOptions<ObiletServiceInfo>>();
            Settings.ObiletServiceInfo = obiletServiceInfo.Value;

            return services;
        }
    }
}
