using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class FreightRegion
    {
        public FreightRegion()
        {
            CommuneFreightRegion = new HashSet<CommuneFreightRegion>();
            DistrictFreightRegion = new HashSet<DistrictFreightRegion>();
            POSFreightRegion = new HashSet<POSFreightRegion>();
            ProvinceFreightRegion = new HashSet<ProvinceFreightRegion>();
        }

        public int Id { get; set; }
        public int DomesticFreightRuleId { get; set; }
        public string FreightRegionCode { get; set; }
        public string ServiceCode { get; set; }
        public string FreightRegionName { get; set; }
        public string Description { get; set; }
        public bool IsSpecial { get; set; }
        public string DomesticFreightRuleCode { get; set; }

        public virtual DomesticFreightRule DomesticFreightRule { get; set; }
        public virtual ICollection<CommuneFreightRegion> CommuneFreightRegion { get; set; }
        public virtual ICollection<DistrictFreightRegion> DistrictFreightRegion { get; set; }
        public virtual ICollection<POSFreightRegion> POSFreightRegion { get; set; }
        public virtual ICollection<ProvinceFreightRegion> ProvinceFreightRegion { get; set; }
    }
}
