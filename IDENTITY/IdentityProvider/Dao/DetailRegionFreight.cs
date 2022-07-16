using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DetailRegionFreight
    {
        public int Id { get; set; }
        public int DomesticFreightStepId { get; set; }
        public string FromFreightRegionCode { get; set; }
        public string ToFreightRegionCode { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public double? Freight { get; set; }
        public double? DomesticMainFreightPercent { get; set; }
        public double? DomesticAirSurchargeFreightPercent { get; set; }
        public double? FromFreightRegionId { get; set; }
        public double? ToFreightRegionId { get; set; }
        public double? DomesticFreightRuleId { get; set; }

        public virtual DomesticFreightStep DomesticFreightStep { get; set; }
    }
}
