using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ServiceItemType
    {
        public ServiceItemType()
        {
            CompensateRate = new HashSet<CompensateRate>();
            RangeServiceItemType = new HashSet<RangeServiceItemType>();
        }

        public string ServiceCode { get; set; }
        public string ItemTypeCode { get; set; }
        public double? DomesticMaximumWeight { get; set; }
        public double? InternationMaximumWeight { get; set; }
        public double? DomesticMinimumFreight { get; set; }
        public double? InternationMinimumWeight { get; set; }
        public double? DomesticMinimumWeight { get; set; }
        public bool? AllowsQuick { get; set; }

        public virtual ItemType ItemTypeCodeNavigation { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
        public virtual ICollection<CompensateRate> CompensateRate { get; set; }
        public virtual ICollection<RangeServiceItemType> RangeServiceItemType { get; set; }
    }
}
