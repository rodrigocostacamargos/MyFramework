using System;
using LGT.Framework.Core.LGTException;

namespace LGT.Framework.Core.Expcetions
{
    public class LGTFactoryNotCreateInstanceException : LGTBaseExpcetion
    {
        public LGTFactoryNotCreateInstanceException(string pLoaderError, Exception ex)
            : base(pLoaderError, ex)
        {

        }

    }
}
