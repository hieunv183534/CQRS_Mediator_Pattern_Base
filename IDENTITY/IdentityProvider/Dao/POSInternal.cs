using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class POSInternal
    {
        public string POSCode { get; set; }
        public string Parent { get; set; }
        public string ParentTag { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
    }
}
