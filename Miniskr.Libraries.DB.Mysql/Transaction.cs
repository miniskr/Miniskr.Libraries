using System;
using System.Data;
using System.Threading.Tasks;

namespace Miniskr.Libraries.DB.Mysql
{
    public class Transaction : ITransaction
    {
        private IPoolConnection _connection;
        private IDbTransaction _transaction;

        public Transaction(IPoolConnection connection)
        {
            this._connection = connection;

            var conn = connection.Connection;
            conn.Open();
            this._transaction = conn.BeginTransaction();
        }

        public void Dispose()
        {
            this._transaction.Dispose();
            this._transaction = null;

            this._connection.Dispose();
            this._connection = null;
        }

        public void Execute(Action<ITransaction> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                action(this);
                this._transaction.Commit();
            }
            catch
            {
                this._transaction.Rollback();
            }
        }

        public async Task ExecuteAsync(Func<ITransaction, Task> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            try
            {
                await action(this);
                this._transaction.Commit();
            }
            catch
            {
                this._transaction.Rollback();
            }
        }

        public IDbConnection GetConnection()
        {
            return this._connection.Connection;
        }

        public IRepository<TModel> GetRepository<TModel>() where TModel : class
        {
            return new Repository<TModel>(this);
        }
    }
}
