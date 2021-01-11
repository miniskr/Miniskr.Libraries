using System;
using System.Threading.Tasks;
using Miniskr.Libraries.DB.Mysql.Configuration;

namespace Miniskr.Libraries.DB.Mysql
{
    public class Database : IDatabase
    {
        private readonly DBDatabaseOptions _options;
        private readonly IConnectionPool _pool;

        public string Name => this._options.Database;

        public Database(DBDatabaseOptions options)
        {
            this._options = options;
            this._pool = new ConnectionPool(options);
        }

        public IPoolConnection BeginConnection()
        {
            return this._pool.BeginConnect();
        }

        public IRepository<TModel> GetRepository<TModel>()
            where TModel : class
        {
            return new Repository<TModel>(this);
        }

        public void Transaction(Action<ITransaction> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            using var trans = new Transaction(this.BeginConnection());
            trans.Execute(action);
        }

        public async Task Transaction(Func<ITransaction, Task> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            using var trans = new Transaction(this.BeginConnection());
            await trans.ExecuteAsync(action);
        }

        public void Dispose()
        {
            this._pool.Dispose();
        }
    }
}
