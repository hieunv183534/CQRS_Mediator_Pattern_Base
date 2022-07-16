using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Delivery_Log
    {
        public long ID { get; set; }
        public long ItemID { get; set; }
        public int DeliveryIndex { get; set; }
        public string ToPOSCode { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public string Action { get; set; }
    }
}
