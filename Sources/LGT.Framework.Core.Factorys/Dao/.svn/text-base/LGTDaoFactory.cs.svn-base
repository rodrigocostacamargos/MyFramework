using System;
using LGT.Framework.Core.Expcetions;
using LGT.Framework.Core.Factorys.Base;
using LGT.Framework.Core.Helper;
using LGT.Framework.Core.Infra;
using LGT.Framework.Core.Interfaces.Dao;

namespace LGT.Framework.Core.Factorys.Dao
{
    public sealed class LGTDaoFactory : LGTBaseFactory<ILGTDaoBase>, ILGTDaoFactory
    {
        private LGTDaoFactory()
        {
        }


        protected override void LoadDependeceAssembly()
        {

        }

        protected override void NotFindConcretTypeForInterface(string pInterfaceName, string pAssemblyName)
        {
            throw new LGTNotFindClassForInterfaceException(pInterfaceName, pAssemblyName);
        }

        protected override T1 CreateInstance<T1>(Type concretType)
        {

            T1 objectReturn;
            if (concretType != null)
                objectReturn = (T1)Activator.CreateInstance(concretType);
            else
                objectReturn = Activator.CreateInstance<T1>();
            return objectReturn;


            //var proxyReturn = concretType != null ? new LGTBaseDaoProxy<T1>(concretType)
            //                                : new LGTBaseDaoProxy<T1>();

            //return proxyReturn.GetTransparentProxy();
        }

        protected override string ConcrectObjectAssemblyName()
        {
            return LGTHelperConfiguraton.ConcretDaoClassAssembly;
        }

        public static ILGTDaoFactory Current
        {
            get
            {
                return new LGTDaoFactory();
            }
        }

    }
}