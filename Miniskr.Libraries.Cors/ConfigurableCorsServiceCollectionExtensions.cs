using Microsoft.Extensions.DependencyInjection;
using System;

namespace Miniskr.Libraries.Cors
{
    public static class ConfigurableCorsServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurableCors(this IServiceCollection services,
            Action<ConfigurableCorsOptions> configure
            )
        {
            var option = new ConfigurableCorsOptions();
            configure?.Invoke(option);

            services.AddCors(op =>
            {
                op.AddPolicy("ConfigurableCors", option.ToPolicy());
            });

            return services;
        }
    }
}
