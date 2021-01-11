﻿using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Miniskr.Libraries.DB.Mysql.Configuration
{
    public static class DBMysqlServiceExtension
    {
        public static IServiceCollection AddDBMysql(this IServiceCollection services, Action<DBClientOptions> configure)
        {
            var options = new DBClientOptions();
            configure?.Invoke(options);

            services.AddSingleton(options);
            services.AddSingleton<IClient, Client>();

            var dbOptions = options.Connections.FirstOrDefault(x => x.Default);
            if (dbOptions != null)
            {
                services.AddSingleton(dbOptions);
                services.AddSingleton<IDatabase, Database>();
                services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            }

            return services;
        }
    }
}
