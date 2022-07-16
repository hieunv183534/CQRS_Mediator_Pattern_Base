using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RangeCommodityType
    {
        public string RangeCode { get; set; }
        public string ServiceCode { get; set; }
        public string CommodityTypeCode { get; set; }

        public virtual Range RangeCodeNavigation { get; set; }
        public virtual ServiceCommodityType ServiceCommodityType { get; set; }
    }
}
