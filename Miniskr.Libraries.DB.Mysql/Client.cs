using System;
using System.Collections.Generic;
using System.Linq;
using Miniskr.Libraries.DB.Mysql.Configuration;

namespace Miniskr.Libraries.DB.Mysql
{
    public class Client : IClient
    {
        private readonly DBClientOptions _options;
        private readonly List<IDatabase> _dbList = new List<IDatabase>();

        public Client(DBClientOptions options)
        {
            this._options = options;
        }

        public void Dispose()
        {
            foreach (var db in this._dbList)
            {
                db.Dispose();
            }
        }

        public IDatabase GetDatabase(string name)
        {
            var database = this._dbList.FirstOrDefault(x => x.Name.Equals(name));
            if (database != null)
                return database;

            var databaseOptions = this._options.Connections.FirstOrDefault(x => x.Database.Equals(name));
            if (databaseOptions == null)
                throw new InvalidOperationException($"can not find database by name: {name}");

            database = new Database(databaseOptions);
            this._dbList.Add(database);
            return database;
        }
    }
}
