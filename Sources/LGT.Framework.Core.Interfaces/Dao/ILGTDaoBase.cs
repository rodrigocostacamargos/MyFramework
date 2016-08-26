﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LGT.Framework.Core.Interfaces.Dao
{
    public interface ILGTDaoBase
    {
    }

    public interface ILGTDaoBase<T> : ILGTDaoBase where T : ILGTEntity
    {
        void Save(T entity);

        void Delete(T entity);
        void DeleteAll(IList<T> entitys);

        IQueryable<T> GetIQueryable();

        T Get(long id);
        T GetFirst();
        T GetLast();
        
        IQueryable<T> GetByCriteria(Func<T, bool> where);

        DbContext GetDbContext { get;  }
    }
}