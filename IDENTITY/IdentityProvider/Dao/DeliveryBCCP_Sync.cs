using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DeliveryBCCP_Sync
    {
        public int DeliveryIndex { get; set; }
        public string ToPOSCode { get; set; }
        public string ItemCode { get; set; }
    }
}
