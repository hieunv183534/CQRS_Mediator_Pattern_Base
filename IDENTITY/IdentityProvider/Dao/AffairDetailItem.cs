using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class AffairDetailItem
    {
        public Guid ItemID { get; set; }
        public int AffairIndex { get; set; }
        public int ItemIndex { get; set; }
        public string ItemCode { get; set; }
        public string DetailItemName { get; set; }
        public double? Quantity { get; set; }
        public double? Amount { get; set; }
        public string Unit { get; set; }
        public double? Price { get; set; }
        public string TaxCode { get; set; }
        public string OriginalCountryCode { get; set; }
        public string ChemicalTypeCode { get; set; }
        public string ChemicalItemName { get; set; }
        public string ChemicalName { get; set; }
        public double? Weight { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Length { get; set; }
        public double? LightItem { get; set; }
        public double? QuantityOld { get; set; }
        public double? AmountOld { get; set; }
        public string UnitOld { get; set; }
        public double? PriceOld { get; set; }
        public string TaxCodeOld { get; set; }
        public string OriginalCountryCodeOld { get; set; }
        public string ChemicalTypeCodeOld { get; set; }
        public string ChemicalItemNameOld { get; set; }
        public string ChemicalNameOld { get; set; }
        public double? WeightOld { get; set; }
        public double? WidthOld { get; set; }
        public double? HeightOld { get; set; }
        public double? LengthOld { get; set; }
        public double? LightItemOld { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
