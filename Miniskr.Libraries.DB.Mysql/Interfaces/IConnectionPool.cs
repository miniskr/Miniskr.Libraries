using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Miniskr.Libraries.DB.Mysql.Interfaces
{
    public interface IConnectionPool : IDisposable
    {
        IDbConnection Rent();
        void Return(IDbConnection connection);
        IPoolConnection BeginConnect();
    }
}
