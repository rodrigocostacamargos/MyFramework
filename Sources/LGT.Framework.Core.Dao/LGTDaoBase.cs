using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using LGT.Framework.Core.Factorys.DBContext;
using LGT.Framework.Core.Interfaces;
using LGT.Framework.Core.Interfaces.Dao;
using LGT.Framework.Core.Interfaces.DBContext.EF;

namespace LGT.Framework.Core.Dao
{
    public class LGTDaoBase<T, T1> : MarshalByRefObject, ILGTDaoBase<T>, IDisposable
        where T : class, ILGTEntity, new()
        where T1 : ILGTDbContex
    {
        protected LGTDaoBase()
        {
            CurrentDbContext = LGTDBContextFactory.Current.GetInstance<T1>();
            CurrentDbSet = CurrentDbContext.Set<T>();
        }

        public IDbSet<T> CurrentDbSet { get; private set; }
        protected ILGTDbContex CurrentDbContext { get; set; }


        #region IDisposable Members

        public void Dispose()
        {
            if (CurrentDbContext != null)
                CurrentDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

        #region ILGTDaoBase<T> Members

        public void Save(T entity)
        {
            //TODO: provisório tentar achar uma forma mais eficiente para colocar no contexto, se for uma importação
            if (entity.Id == 0)
                CurrentDbSet.Add(entity);
            else
            {

                var entry = GetDbContext.ChangeTracker.Entries().FirstOrDefault(x => ((ILGTEntity)x.Entity).Id == entity.Id);
                if (entry != null)
                {
                    var concretType = entity.GetType();
                    var propertysToClone = concretType.GetProperties().Where(x => !x.PropertyType.IsNested && x.CanWrite).ToList();

                    foreach (var p in propertysToClone)
                    {
                        p.SetValue(entry.Entity, p.GetValue(entity, new object[0]), new object[0]);
                    }

                }
                else
                {
                    GetDbContext.Entry(entity).State = EntityState.Modified;
                }
            }
            this.SaveChanges();
        }

        public void Delete(T entity)
        {
            CurrentDbSet.Remove(entity);
            SaveChanges();
        }

        public void DeleteAll(IList<T> entitys)
        {
            using (var dbTrans = CurrentDbContext.Database.Connection.BeginTransaction())
            {
                try
                {
                    entitys.ToList().ForEach(Delete);
                    dbTrans.Commit();
                }
                catch (Exception)
                {
                    dbTrans.Rollback();
                    throw;
                }
            }
        }

        public T Get(long id)
        {
            return CurrentDbSet.Find(id);
        }


        public T GetFirst()
        {
            return CurrentDbSet.FirstOrDefault();
        }

        public T GetLast()
        {
            return CurrentDbSet.LastOrDefault();
        }

        public IQueryable<T> GetIQueryable()
        {
            return CurrentDbSet;
        }

        public IQueryable<T> GetByCriteria(Func<T, bool> where)
        {
            return CurrentDbSet.Where(where).AsQueryable();
        }

        #endregion

        protected virtual void SaveChanges()
        {
            GetDbContext.ChangeTracker.DetectChanges();
            GetDbContext.SaveChanges();
        }


        public virtual DbContext GetDbContext
        {
            get { return ((DbContext)this.CurrentDbContext); }
        }



    }
}