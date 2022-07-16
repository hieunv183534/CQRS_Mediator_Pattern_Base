using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticFreightRule
    {
        public DomesticFreightRule()
        {
            DomesticFarRegion = new HashSet<DomesticFarRegion>();
            DomesticFarRegionCommune = new HashSet<DomesticFarRegionCommune>();
            DomesticFarRegionFreightStep = new HashSet<DomesticFarRegionFreightStep>();
            DomesticFreightBlock = new HashSet<DomesticFreightBlock>();
            DomesticFreightStep = new HashSet<DomesticFreightStep>();
            DomesticValueAddedServiceFreightPerItem = new HashSet<DomesticValueAddedServiceFreightPerItem>();
            DomesticValueAddedServiceFreightPercentMainFreight = new HashSet<DomesticValueAddedServiceFreightPercentMainFreight>();
            FreightRegion = new HashSet<FreightRegion>();
        }

        public int Id { get; set; }
        public string DomesticFreightRuleCode { get; set; }
        public DateTime ValueDate { get; set; }
        public string RuleNo { get; set; }
        public string ServiceCode { get; set; }
        public double? CollectionFreight { get; set; }
        public double? CollectionFreightPercent { get; set; }
        public double? HeavyItemFactor { get; set; }
        public double? FragileItemFactor { get; set; }
        public double? OtherFactor { get; set; }
        public string MainFreightStoreProcedure { get; set; }
        public string ValueAddedServiceFreightStoreProcedure { get; set; }
        public string MainFreightFormula { get; set; }
        public string ValueAddedServiceFreightFormula { get; set; }
        public bool? HasVAT { get; set; }
        public double? VATPercent { get; set; }
        public string ProvinceCode { get; set; }
        public string CustomerCode { get; set; }
        public byte? CommodityCalculationMethod { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public double? FarRegionCoefficient { get; set; }
        public int? FarRegionFreightType { get; set; }
        public int? BatchCalculateMethod { get; set; }
        public double? FuelFreightCoefficient { get; set; }

        public virtual DomesticValueAddedServiceFreightStep DomesticValueAddedServiceFreightStep { get; set; }
        public virtual ICollection<DomesticFarRegion> DomesticFarRegion { get; set; }
        public virtual ICollection<DomesticFarRegionCommune> DomesticFarRegionCommune { get; set; }
        public virtual ICollection<DomesticFarRegionFreightStep> DomesticFarRegionFreightStep { get; set; }
        public virtual ICollection<DomesticFreightBlock> DomesticFreightBlock { get; set; }
        public virtual ICollection<DomesticFreightStep> DomesticFreightStep { get; set; }
        public virtual ICollection<DomesticValueAddedServiceFreightPerItem> DomesticValueAddedServiceFreightPerItem { get; set; }
        public virtual ICollection<DomesticValueAddedServiceFreightPercentMainFreight> DomesticValueAddedServiceFreightPercentMainFreight { get; set; }
        public virtual ICollection<FreightRegion> FreightRegion { get; set; }
    }
}
