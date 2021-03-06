﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LGT.Framework.Core.Interfaces.DBContext.EF;

namespace LGT.Framework.Core.DBContext
{
    public abstract class LGTEFDBContext : DbContext, ILGTDbContex
    {
        protected LGTEFDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;


        }

        protected abstract void ConfiguraModel(DbModelBuilder modelBuilder);

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfiguraModel(modelBuilder);
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}