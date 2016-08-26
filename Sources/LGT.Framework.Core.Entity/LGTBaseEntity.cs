﻿using LGT.Framework.Core.Interfaces;

namespace LGT.Framework.Core.Entity
{
    public class LGTBaseEntity : ILGTEntity
    {
        #region ILGTEntity Members

        public virtual long Id { get; set; }

        #endregion
    }
}