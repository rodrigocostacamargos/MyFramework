using System;
using System.Collections.Generic;
using LGT.Framework.Core.Factorys.Dao;
using LGT.Framework.Core.Interfaces;
using LGT.Framework.Core.Interfaces.Biz;
using LGT.Framework.Core.Interfaces.Dao;
using System.Linq;

namespace LGT.Framework.Core.Biz
{
    public class LGTBizBase<T, T1> : MarshalByRefObject, ILGTBizBase<T>
        where T : ILGTEntity
        where T1 : ILGTDaoBase<T>
    {
        protected LGTBizBase()
        {

        }

        #region DAO


        protected T1 Dao
        {
            get
            {
                return LGTDaoFactory.Current.GetInstance<T1>();
            }
        }

        protected T2 GetDao<T2>() where T2 : ILGTDaoBase
        {
            return LGTDaoFactory.Current.GetInstance<T2>();
        }
        #endregion

        protected virtual bool ValidateEntityToSave(T entity)
        {
            return true;
        }

        protected virtual bool ValidateEntityToDelete(T entity)
        {
            return true;
        }

        #region ILGTBizBase<T> Members

        public void Save(T entity)
        {
            if (ValidateEntityToSave(entity))
                Dao.Save(entity);
        }

        public void Delete(T entity)
        {
            if (ValidateEntityToDelete(entity))
                Dao.Delete(entity);
        }

        public void DeleteAll(IList<T> entitys)
        {
            var canDelete = true;
            foreach (var entity in entitys)
            {
                canDelete = ValidateEntityToDelete(entity);
                if (!canDelete)
                    break;
            }

            if (canDelete)
                Dao.DeleteAll(entitys);
        }

        public T GetFirst()
        {
            return Dao.GetFirst();
        }

        public T Get(long id)
        {
            return Dao.Get(id);
        }

        public IList<T> GetAll()
        {
            return Dao.GetIQueryable().ToList();
        }

        public T GetLast()
        {
            return Dao.GetLast();
        }

        public IList<T> GetByCriteria(Func<T, bool> where)
        {
            return Dao.GetByCriteria(where).ToList();
        }
        #endregion

    }
}