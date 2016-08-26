using System;
using System.Collections.Generic;

namespace LGT.Framework.Core.Interfaces.Biz
{
    public interface ILGTBizBase
    {
    }

    public interface ILGTBizBase<T> : ILGTBizBase where T : ILGTEntity
    {
        void Save(T entity);

        void Delete(T entity);
        void DeleteAll(IList<T> entitys);

        
        T Get(long id);
        T GetFirst();
        T GetLast();

        IList<T> GetAll();

        IList<T> GetByCriteria(Func<T, bool> where);
    }
}