using System;
using System.Data;

namespace Miniskr.Libraries.DB.Mysql
{
    public interface IPoolConnection : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
