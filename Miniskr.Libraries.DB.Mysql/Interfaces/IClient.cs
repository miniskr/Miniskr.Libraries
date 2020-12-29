using System;

namespace Miniskr.Libraries.DB.Mysql.Interfaces
{
    public interface IClient : IDisposable
    {
        IDatabase GetDatabase(string name);
    }
}
