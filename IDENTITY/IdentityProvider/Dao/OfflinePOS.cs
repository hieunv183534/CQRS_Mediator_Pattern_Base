using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class OfflinePOS
    {
        public string OfflinePOSCode { get; set; }
        public string OnlinePOSCode { get; set; }

        public virtual POS OfflinePOSCodeNavigation { get; set; }
        public virtual POS OnlinePOSCodeNavigation { get; set; }
    }
}
