using System;

namespace Miniskr.Libraries.DB.Mysql
{
    public interface IClient : IDisposable
    {
        IDatabase GetDatabase(string name);
    }
}
