using System;
using System.Data.Entity.Infrastructure;

namespace LGT.Framework.Core.Interfaces.DBContext.EF
{
    public interface ILGTDbContex : IDisposable
    {
        System.Data.Entity.DbSet<T> Set<T>() where T : class;
        System.Data.Entity.Database Database { get; }
        
        int SaveChanges();

    }
}