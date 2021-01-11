using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;

namespace Miniskr.Libraries.DB.Mysql
{
    public class Repository<TModel> : DapperRepository<TModel>, IRepository<TModel>
        where TModel : class
    {
        private IPoolConnection _connection;

        public Repository(IDbConnection connection)
            :base(connection)
        {
        }

        public Repository(IPoolConnection connection)
            : this(connection.Connection)
        {
            this._connection = connection;
        }

        public Repository(IDatabase database)
            :this(database.BeginConnection())
        {
        }

        public Repository(ITransaction transaction)
            :this(transaction.GetConnection())
        {
        }


        //public void Dispose()
        //{
        //    if(this._connection != null)
        //    {
        //        this._connection.Dispose();
        //        this._connection = null;
        //    }
        //}

        public TModel FindOrInsert(Expression<Func<TModel, bool>> predicate, TModel model)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            if(model == null)
                throw new ArgumentNullException(nameof(model));

            var found = this.Find(predicate);
            if(found == null)
            {
                found = model;
                this.Insert(model);
            }

            return found;
        }

        public async Task<TModel> FindOrInsertAsync(Expression<Func<TModel, bool>> predicate, TModel model)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var found = await this.FindAsync(predicate);
            if (found == null)
            {
                found = model;
                await this.InsertAsync(model);
            }

            return found;
        }

        public bool UpdateOrInsert(Expression<Func<TModel, bool>> predicate, TModel model)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (!this.Update(predicate, model))
            {
                this.Insert(model);
            }

            return true;
        }

        public async Task<bool> UpdateOrInsertAsync(Expression<Func<TModel, bool>> predicate, TModel model)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (!await this.UpdateAsync(predicate, model))
            {
                await this.InsertAsync(model);
            }

            return true;
        }

    }
}
