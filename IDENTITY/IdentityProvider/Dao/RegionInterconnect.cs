using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RegionInterconnect
    {
        public int Id { get; set; }
        public int DomesticFreightRuleId { get; set; }
        public string FromFreightRegionCode { get; set; }
        public string ToFreightRegionCode { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public string ServiceCode { get; set; }
        public double? DomesticMainFreightPercent { get; set; }
        public double? DomesticAirSurchargeFreightPercent { get; set; }
        public int? DomesticFreightBlockId { get; set; }

        public virtual DomesticFreightBlock DomesticFreightBlock { get; set; }
    }
}
