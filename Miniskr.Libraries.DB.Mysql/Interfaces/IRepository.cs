using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MicroOrm.Dapper.Repositories;

namespace Miniskr.Libraries.DB.Mysql.Interfaces
{
    public interface IRepository<TModel> : IDapperRepository<TModel>, IDisposable
        where TModel : class
    {
        TModel FindOrInsert(Expression<Func<TModel, bool>> predicate, TModel model);
        Task<TModel> FindOrInsertAsync(Expression<Func<TModel, bool>> predicate, TModel model);

        bool UpdateOrInsert(Expression<Func<TModel, bool>> predicate, TModel model);
        Task<bool> UpdateOrInsertAsync(Expression<Func<TModel, bool>> predicate, TModel model);
    }
}
