using System.Collections.Generic;

namespace Miniskr.Libraries.DB.Mysql.Configuration
{
    public class DBClientOptions
    {
        public List<DBDatabaseOptions> Connections { get; set; } = new List<DBDatabaseOptions>();
    }
}
