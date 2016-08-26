using System;

namespace LGT.Framework.Core.LGTException
{
    public class LGTBaseExpcetion : Exception
    {
        public LGTBaseExpcetion()
            : this("Ocorreu um comportamento não previsto no sistema.")
        {
        }

        public LGTBaseExpcetion(string message)
            : this(message, message)
        {
        }

        public LGTBaseExpcetion(string message, string friendlymessage)
            : base(message)
        {
            FriendlyMessage = friendlymessage;
        }

        public string FriendlyMessage { get; set; }
    }
}