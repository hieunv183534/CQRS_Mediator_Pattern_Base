using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class POSInternalFull
    {
        public string POSCode { get; set; }
        public string Parent { get; set; }
        public string ParentTag { get; set; }
        public string PosName { get; set; }
        public bool? IsPos { get; set; }
    }
}
