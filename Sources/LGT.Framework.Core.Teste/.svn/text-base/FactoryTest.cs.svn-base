using System;
using System.Collections.Generic;
using System.Data.Entity;
using LGT.Framework.Core.Biz;
using LGT.Framework.Core.Dao;
using LGT.Framework.Core.DBContext;
using LGT.Framework.Core.EFTypeConfiguration;
using LGT.Framework.Core.Entity;
using LGT.Framework.Core.Factorys.Biz;
using LGT.Framework.Core.Helper;
using LGT.Framework.Core.Interfaces.Biz;
using LGT.Framework.Core.Interfaces.Dao;
using LGT.Framework.Core.Interfaces.DBContext.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LGTFrameworkTeste
{
    public class VBPLDBContext : LGTEFDBContext, IVBPLDBContext
    {
        public VBPLDBContext()
            : base(LGTHelperConfiguraton.ConnectionString)
        {

        }



        protected override void ConfiguraModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmpresaMap());

        }
        public DbSet<Empresa> Empresas { get; set; }
    }
    public class EmpresaMap : LGTEntityBaseConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            Property(p => p.Nome);
            Property(p => p.CNPJ);
            Ignore(p => p.Bot);

        }

        protected override string TableName
        {
            get { return "dbo.Empresa"; }
        }
    }
    public interface IVBPLDBContext : ILGTDbContex
    {
        DbSet<Empresa> Empresas { get; set; }
    }
    public class EmpresaBiz : LGTBizBase<Empresa, IDaoEmpresa>, IBizEmpresa
    {

    }

    public class EmpresaDAO : LGTDaoBase<Empresa, IVBPLDBContext>, IDaoEmpresa
    {

    }

    public interface IBizEmpresa : ILGTBizBase<Empresa>
    {

    }

    public interface IDaoEmpresa : ILGTDaoBase<Empresa>
    {
    }

    public class Foo
    {
        public string Bot { get; set; }
    }
    public class Empresa : LGTBaseEntity
    {
        public virtual string Nome { get; set; }
        public virtual string CNPJ { get; set; }
        public Foo Bot { get; set; }

    }

    [TestClass]
    public class FactoryCreateObjectTeste
    {


        [TestMethod]
        public void TestOutMethods()
        {


            var iemp = LGTBizFactory.Current.GetInstance<IBizEmpresa>();
            var retorno = iemp.Get(16);
            //var iemp2 = LGTBizFactory.Current.GetInstance<IBizEmpresa>();
            retorno.Nome = DateTime.Now.ToString();
            iemp.Save(retorno);


        }
    }
}

