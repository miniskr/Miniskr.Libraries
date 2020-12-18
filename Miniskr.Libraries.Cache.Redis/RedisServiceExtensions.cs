using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Miniskr.Libraries.Cache.Redis
{
    public static class RedisServiceExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, Action<RedisOptions> configure = null)
        {
            var options = new RedisOptions();
            configure?.Invoke(options);

            services.AddStackExchangeRedisCache(op =>
            {
                op.Configuration = options.ConnectString;
                op.InstanceName = options.InstanceName;
            });

            return services;
        }
    }
}
