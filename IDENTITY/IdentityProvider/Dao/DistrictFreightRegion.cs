using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DistrictFreightRegion
    {
        public int Id { get; set; }
        public int FreightRegionId { get; set; }
        public string FreightRegionCode { get; set; }
        public string ServiceCode { get; set; }
        public string DistrictCode { get; set; }
        public string DomesticFreightRuleCode { get; set; }

        public virtual District DistrictCodeNavigation { get; set; }
        public virtual FreightRegion FreightRegion { get; set; }
    }
}
