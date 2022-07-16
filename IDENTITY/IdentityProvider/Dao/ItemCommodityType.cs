using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemCommodityType
    {
        public long ItemID { get; set; }
        public string ItemCode { get; set; }
        public string CommodityTypeCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual CommodityType CommodityTypeCodeNavigation { get; set; }
    }
}
