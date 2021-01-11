using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Miniskr.Libraries.DB.Mysql.Configuration;
using MySql.Data.MySqlClient;

namespace Miniskr.Libraries.DB.Mysql
{
    public class ConnectionPool : IConnectionPool
    {
        public const int SIZE = 0x10;

        private int _capacity = 0;
        private readonly Stack<IDbConnection> _connectionAvaliable = new Stack<IDbConnection>();
        private readonly List<IDbConnection> _connectionList = new List<IDbConnection>();

        private readonly string _connectionString;

        public ConnectionPool(DBDatabaseOptions options)
        {
            this._connectionString = options.BuildConnectionString();
            if (this._connectionString == null)
                throw new InvalidOperationException($"connection string is null");


        }

        private void Extend(int size = SIZE)
        {
            for (int i = 0; i < size; i++)
            {
                var connection = new MySqlConnection(this._connectionString);
                this._connectionAvaliable.Push(connection);
                this._connectionList.Add(connection);
            }
            this._capacity += size;
        }

        public IPoolConnection BeginConnect()
        {
            return new PoolConnection(this);
        }

        public IDbConnection Rent()
        {
            if (this._connectionAvaliable.Count == 0)
                this.Extend(this._capacity);

            var connection = this._connectionAvaliable.Pop();
            if (connection == null)
                throw new InvalidOperationException("pop null connection");

            return connection;
        }

        public void Return(IDbConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            if (!this._connectionList.Any(item => object.ReferenceEquals(item, connection)))
                throw new InvalidOperationException("not a connection for this pool");

            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }

            this._connectionAvaliable.Push(connection);
        }

        public void Dispose()
        {
            foreach (var connection in this._connectionAvaliable)
            {
                connection.Dispose();
            }
        }

    }
}
