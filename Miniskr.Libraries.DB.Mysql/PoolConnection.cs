using System.Data;

namespace Miniskr.Libraries.DB.Mysql
{
    public class PoolConnection : IPoolConnection
    {
        private IConnectionPool _pool;

        public IDbConnection Connection { get; private set; }

        public PoolConnection(IConnectionPool pool)
        {
            this._pool = pool;
            this.Connection = pool.Rent();
        }

        public void Dispose()
        {
            this._pool.Return(this.Connection);
            this._pool = null;
            this.Connection = null;
        }
    }
}
