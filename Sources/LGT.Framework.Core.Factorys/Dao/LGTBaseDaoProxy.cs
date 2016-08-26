using System;
using System.Threading;
using LGT.Framework.Core.Factorys.Base;
using LGT.Framework.Core.Helper;
using LGT.Framework.Core.Infra;
using LGT.Framework.Core.Expcetions;

namespace LGT.Framework.Core.Factorys.Dao
{
    public class LGTBaseDaoProxy<T> : LGTBaseRealProxy<T>
    {
        protected override void MethodNotFound(string pMethodName, string pRealObjectType)
        {
            throw new LGTTransparentProxyNotFoundMethodException(pMethodName, pRealObjectType);
        }

        protected override bool UsingTransaction
        {
            get
            {
                return LGTHelperConfiguraton.UsingTransactionScopeProxy;
            }
        }
        public LGTBaseDaoProxy()
        {
        }

        public LGTBaseDaoProxy(Type type)
            : base(type)
        {

        }
    }
}