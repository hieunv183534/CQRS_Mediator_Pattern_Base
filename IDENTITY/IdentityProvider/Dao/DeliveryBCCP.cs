using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DeliveryBCCP
    {
        public long id { get; set; }
        public int DeliveryIndex { get; set; }
        public string ToPOSCode { get; set; }
        public string ItemCode { get; set; }
    }
}
