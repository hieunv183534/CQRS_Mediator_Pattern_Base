using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DetailProvinceFreight
    {
        public int Id { get; set; }
        public int DomesticFreightStepId { get; set; }
        public int ProvinceInterconnectId { get; set; }
        public string FromProvinceCode { get; set; }
        public string ToProvinceCode { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public double? Freight { get; set; }
        public double? DomesticMainFreightPercent { get; set; }
        public double? DomesticAirSurchargeFreightPercent { get; set; }
        public double? DomesticFreightRuleId { get; set; }

        public virtual DomesticFreightStep DomesticFreightStep { get; set; }
    }
}
