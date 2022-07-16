using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class CompensateRate
    {
        public string CompensateRateCode { get; set; }
        public string ItemTypeCode { get; set; }
        public string ServiceCode { get; set; }
        public double? FromWeight { get; set; }
        public double? ToWeight { get; set; }
        public double? CompensateMoney { get; set; }
        public DateTime? ValueDate { get; set; }

        public virtual ServiceItemType ServiceItemType { get; set; }
    }
}
