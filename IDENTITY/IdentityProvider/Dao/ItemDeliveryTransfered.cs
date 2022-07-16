using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemDeliveryTransfered
    {
        public long ItemID { get; set; }
        public string Direct { get; set; }
        public string ToPOSCode { get; set; }
        public int DeliveryIndex { get; set; }
        public string ItemCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
