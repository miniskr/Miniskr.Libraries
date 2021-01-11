using MySql.Data.MySqlClient;

namespace Miniskr.Libraries.DB.Mysql.Configuration
{
    public class DBDatabaseOptions
    {
        public bool Default { get; set; }

        public string Host { get; set; } = "localhost";
        public uint Port { get; set; } = 3306;
        public string Database { get; set; }
        public string UserId { get; set; } = "root";
        public string Password { get; set; }
        public MySqlSslMode SslMode { get; set; } = MySqlSslMode.None;
        public string Characterset { get; set; } = "utf8";

        public string BuildConnectionString()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = this.Host,
                Port = this.Port,
                Database = this.Database,
                CharacterSet = this.Characterset,
                SslMode = this.SslMode,
                UserID = this.UserId,
                Password = this.Password
            };

            return builder.GetConnectionString(true);
        }
    }
}
