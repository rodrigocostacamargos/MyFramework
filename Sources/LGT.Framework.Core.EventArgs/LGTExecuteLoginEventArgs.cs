﻿using System;
using LGT.Framework.Core.Enums;

namespace LGT.Framework.Core.EventArguments
{
    public class LGTExecuteLoginEventArgs : EventArgs
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public int Id { get; set; }
        public bool Autenticated { get; set; }
        public LoginType LoginType { get; set; }
    }


}