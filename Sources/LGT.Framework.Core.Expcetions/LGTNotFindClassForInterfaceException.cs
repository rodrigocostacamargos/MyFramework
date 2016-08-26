using LGT.Framework.Core.Infra;
using LGT.Framework.Core.LGTException;

namespace LGT.Framework.Core.Expcetions
{
    public class LGTNotFindClassForInterfaceException : LGTBaseExpcetion
    {

        public LGTNotFindClassForInterfaceException(string interfaceName, string assemblyName)
            : base(string.Format(LGTConsts.LGTExceptionMessage.NotFindClassForInterface, interfaceName, assemblyName))
        {

        }
    }
}
