using System;
using System.Data;

namespace Miniskr.Libraries.DB.Mysql
{
    public interface IConnectionPool : IDisposable
    {
        IPoolConnection BeginConnect();
        IDbConnection Rent();
        void Return(IDbConnection connection);
    }
}
