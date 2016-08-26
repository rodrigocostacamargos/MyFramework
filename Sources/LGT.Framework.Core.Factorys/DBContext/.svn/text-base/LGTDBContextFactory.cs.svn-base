using LGT.Framework.Core.Expcetions;
using LGT.Framework.Core.Factorys.Base;
using LGT.Framework.Core.Helper;
using LGT.Framework.Core.Interfaces.Base;
using LGT.Framework.Core.Interfaces.DBContext.EF;

namespace LGT.Framework.Core.Factorys.DBContext
{
    public sealed class LGTDBContextFactory : LGTBaseFactory<ILGTDbContex>, ILGTDBContextFactory
    {
        private LGTDBContextFactory()
        {
        }

        protected override void LoadDependeceAssembly()
        {

        }

        protected override void NotFindConcretTypeForInterface(string pInterfaceName, string pAssemblyName)
        {
            throw new LGTNotFindClassForInterfaceException(pInterfaceName, pAssemblyName);
        }


        protected override string ConcrectObjectAssemblyName()
        {
            return LGTHelperConfiguraton.ConcretDBContextAssembly;
        }

        public static ILGTDBContextFactory Current
        {
            get
            {
                return new LGTDBContextFactory();
            }
        }

    }
}