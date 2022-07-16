using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticFreightBlock
    {
        public DomesticFreightBlock()
        {
            DetailBlockFreight = new HashSet<DetailBlockFreight>();
            ProvinceInterconnect = new HashSet<ProvinceInterconnect>();
            RegionInterconnect = new HashSet<RegionInterconnect>();
        }

        public int Id { get; set; }
        public int DomesticFreightRuleId { get; set; }
        public string BlockCode { get; set; }
        public string BlockName { get; set; }
        public double? DomesticMainFreightPercent { get; set; }
        public double? DomesticAirSurchargeFreightPercent { get; set; }

        public virtual DomesticFreightRule DomesticFreightRule { get; set; }
        public virtual ICollection<DetailBlockFreight> DetailBlockFreight { get; set; }
        public virtual ICollection<ProvinceInterconnect> ProvinceInterconnect { get; set; }
        public virtual ICollection<RegionInterconnect> RegionInterconnect { get; set; }
    }
}
