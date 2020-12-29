using System;
using System.Data;

namespace Miniskr.Libraries.DB.Mysql.Interfaces
{
    public interface IPoolConnection : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
