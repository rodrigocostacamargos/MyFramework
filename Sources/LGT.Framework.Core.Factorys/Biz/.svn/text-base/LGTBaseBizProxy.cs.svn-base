using System;
using LGT.Framework.Core.Expcetions;
using LGT.Framework.Core.Factorys.Base;
using LGT.Framework.Core.Helper;

namespace LGT.Framework.Core.Factorys.Biz
{
    public class LGTBaseBizProxy<T> : LGTBaseRealProxy<T>
    {
        public LGTBaseBizProxy()
        {
        }

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

        public LGTBaseBizProxy(Type type)
            : base(type)
        {

        }
    }
}