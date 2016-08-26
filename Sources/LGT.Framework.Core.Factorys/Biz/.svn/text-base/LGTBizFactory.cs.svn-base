using System;
using System.Reflection;
using LGT.Framework.Core.Expcetions;
using LGT.Framework.Core.Factorys.Base;
using LGT.Framework.Core.Helper;
using LGT.Framework.Core.Interfaces.Biz;

namespace LGT.Framework.Core.Factorys.Biz
{
    public sealed class LGTBizFactory : LGTBaseFactory<ILGTBizBase>, ILGTBizFactory
    {
        private LGTBizFactory()
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



            //var proxyReturn = concretType != null ? new LGTBaseBizProxy<T1>(concretType)
            //                                     : new LGTBaseBizProxy<T1>();

            //return proxyReturn.GetTransparentProxy();
        }
        protected override void LoadDependeceAssembly()
        {
            Assembly.LoadFrom(LGTHelperConfiguraton.ConcretDaoClassAssembly);
        }
        protected override string ConcrectObjectAssemblyName()
        {

            return LGTHelperConfiguraton.ConcretBizClassAssembly;
        }

        public static ILGTBizFactory Current
        {
            get
            {
                return new LGTBizFactory();
            }
        }
    }
}