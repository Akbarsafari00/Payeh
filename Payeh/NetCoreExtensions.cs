using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payeh.Options;
using Payeh.Utilities.Services;
using Payeh.Utilities.Services.Logger;
using Payeh.Utilities.Services.Translations;

namespace Payeh
{
    public static class NetCoreExtensions
    {
        public static IServiceCollection AddPayeh(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices(configuration);
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var payehOptions = new PayehOptions();
            configuration.GetSection("Payeh").Bind(payehOptions);

            services.AddSingleton<PayehOptions>(payehOptions);
            
            
            if (payehOptions.Services.Translator != null)
            {
                switch (payehOptions.Services.Translator.Type.ToLower())
                {
                    case "google":
                        services.AddTransient<ITranslator, GoogleTranslator>();
                        break;
                    default:
                        services.AddTransient<ITranslator, GoogleTranslator>();
                        break;
                }
            }
            if (payehOptions.Services.Logger != null)
            {
                switch (payehOptions.Services.Logger.Type.ToLower())
                {
                    default:
                        services.AddTransient<ILogger, Logger>();
                        break;
                }
            }

            services.AddTransient<IPayehService, PayehService>();
            return services;
        }
    }
}