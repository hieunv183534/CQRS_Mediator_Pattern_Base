using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticFreightStep
    {
        public DomesticFreightStep()
        {
            DetailBlockFreight = new HashSet<DetailBlockFreight>();
            DetailProvinceFreight = new HashSet<DetailProvinceFreight>();
            DetailRegionFreight = new HashSet<DetailRegionFreight>();
        }

        public int Id { get; set; }
        public string DomesticFreightStepCode { get; set; }
        public string ServiceCode { get; set; }
        public int DomesticFreightRuleId { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public double FromWeight { get; set; }
        public double ToWeight { get; set; }
        public string ItemTypeCode { get; set; }
        public double FreightStep { get; set; }
        public byte CalculationMethod { get; set; }
        public bool? IsBatch { get; set; }
        public double? InternalProvinceFreight { get; set; }
        public byte? TransportType { get; set; }

        public virtual DomesticFreightRule DomesticFreightRule { get; set; }
        public virtual ItemType ItemTypeCodeNavigation { get; set; }
        public virtual ICollection<DetailBlockFreight> DetailBlockFreight { get; set; }
        public virtual ICollection<DetailProvinceFreight> DetailProvinceFreight { get; set; }
        public virtual ICollection<DetailRegionFreight> DetailRegionFreight { get; set; }
    }
}
