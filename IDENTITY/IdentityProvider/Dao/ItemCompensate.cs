using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemCompensate
    {
        public long ItemID { get; set; }
        public string ItemCode { get; set; }
        public double? CompensateMoney { get; set; }
        public DateTime? CompensateDate { get; set; }
        public string CompensateReason { get; set; }
        public string CompensateUsername { get; set; }
        public string CompensatePOSCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
