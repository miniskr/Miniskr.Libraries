using System;
using System.Data;
using System.Threading.Tasks;

namespace Miniskr.Libraries.DB.Mysql
{
    public interface ITransaction : IDisposable
    {
        IDbConnection GetConnection();

        IRepository<TModel> GetRepository<TModel>()
            where TModel : class;

        void Execute(Action<ITransaction> action);
        Task ExecuteAsync(Func<ITransaction, Task> action);
    }
}
