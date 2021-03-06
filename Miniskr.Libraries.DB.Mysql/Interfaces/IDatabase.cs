﻿using System;
using System.Threading.Tasks;

namespace Miniskr.Libraries.DB.Mysql
{
    public interface IDatabase : IDisposable
    {
        string Name { get; }
        IRepository<TModel> GetRepository<TModel>()
            where TModel : class;

        IPoolConnection BeginConnection();

        void Transaction(Action<ITransaction> action);
        Task Transaction(Func<ITransaction, Task> action);
    }
}
