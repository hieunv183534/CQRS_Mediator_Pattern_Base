using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ProvinceInterconnect
    {
        public int Id { get; set; }
        public int DomesticFreightRuleId { get; set; }
        public string FromProvinceCode { get; set; }
        public string ToProvinceCode { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public string ServiceCode { get; set; }
        public double? DomesticMainFreightPercent { get; set; }
        public double? DomesticAirSurchargeFreightPercent { get; set; }
        public int? DomesticFreightBlockId { get; set; }

        public virtual DomesticFreightBlock DomesticFreightBlock { get; set; }
        public virtual Province FromProvinceCodeNavigation { get; set; }
        public virtual Province ToProvinceCodeNavigation { get; set; }
    }
}
