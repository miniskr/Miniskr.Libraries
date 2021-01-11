using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Miniskr.Libraries.DB.Mysql.Test.Models;
using System.Threading.Tasks;
using System.Data;

namespace Miniskr.Libraries.DB.Mysql.Test
{
    public class DBTest : TestBase
    {
        [Fact]
        public void TestDefault()
        {
            using var provider = this.BuildProvider();

            var client = provider.GetService<IClient>();
            Assert.NotNull(provider);

            var db1 = client.GetDatabase("test_001");
            Assert.NotNull(db1);
            Assert.Equal("test_001", db1.Name);

            var db2 = client.GetDatabase("test_002");
            Assert.NotNull(db2);
            Assert.Equal("test_002", db2.Name);

            var repoUser1 = db1.GetRepository<User>();
            var repoUser2 = db2.GetRepository<User>();

            var tasks = new List<Task>();
            var conns = new List<IDbConnection>();

            for (var j = 0; j < 5; ++j)
            {
                tasks.Add(Task.Run(() =>
                {
                    var repoUser = db1.GetRepository<User>();
                    var contains = conns.Contains(repoUser.Connection);
                    Assert.False(contains);

                    conns.Add(repoUser.Connection);
                    for (var i = 0; i < 50; ++i)
                    {
                        var user = new User
                        {
                            Name = $"name{i.ToString("D2")}",
                            Age = i,
                        };
                        repoUser.Insert(user);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}
