using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Controls
    {
        public int ControlId { get; set; }
        public int ObjectRefId { get; set; }
        public string ControlName { get; set; }
        public string ControlType { get; set; }
        public bool? IsDisable { get; set; }
        public bool? IsInvisible { get; set; }
    }
}
