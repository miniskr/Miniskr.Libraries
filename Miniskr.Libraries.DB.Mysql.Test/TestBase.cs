using Microsoft.Extensions.DependencyInjection;
using Miniskr.Libraries.DB.Mysql.Configuration;

namespace Miniskr.Libraries.DB.Mysql.Test
{
    public abstract class TestBase
    {
        protected virtual ServiceProvider BuildProvider()
        {
            var services = new ServiceCollection();

            services.AddDBMysql(options =>
            {
                options.Connections.Add(new DBDatabaseOptions()
                {
                    Host = "192.168.79.131",
                    UserId = "miniskr",
                    Database = "test_001",
                    Password = "test123!"
                });

                options.Connections.Add(new DBDatabaseOptions()
                {
                    Default = true,
                    Host = "192.168.79.131",
                    UserId = "miniskr",
                    Database = "test_002",
                    Password = "test123!",
                }); ;
            });

            return services.BuildServiceProvider();
        }
    }
}
