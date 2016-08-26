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
            : this(message, message, null)
        {
        }

        public LGTBaseExpcetion(string message, string friendlymessage)
            : this(message, friendlymessage, null)
        {
        }
        public LGTBaseExpcetion(string message, Exception exinner)
            : this(message, message, exinner)
        {
        }
        public LGTBaseExpcetion(string message, string friendlymessage, Exception exinner)
            : base(message, exinner)
        {
            FriendlyMessage = friendlymessage;
        }

        public string FriendlyMessage { get; set; }
    }
}