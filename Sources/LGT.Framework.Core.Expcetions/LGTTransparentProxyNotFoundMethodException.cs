using LGT.Framework.Core.Infra;
using LGT.Framework.Core.LGTException;

namespace LGT.Framework.Core.Expcetions
{
    public class LGTTransparentProxyNotFoundMethodException: LGTBaseExpcetion
    {
        public LGTTransparentProxyNotFoundMethodException(string pMethodName, string pRealType)
            : base(string.Format(LGTConsts.LGTExceptionMessage.NotFindMethodInRealType, pMethodName, pRealType))
        {

        }
    }
}

