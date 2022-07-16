using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemCommodityType_Sync
    {
        public string ItemCode { get; set; }
        public string CommodityTypeCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
