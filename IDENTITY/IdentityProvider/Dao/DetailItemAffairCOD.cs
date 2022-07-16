using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DetailItemAffairCOD
    {
        public long ItemID { get; set; }
        public int ItemIndex { get; set; }
        public string ItemCode { get; set; }
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
        public string DetailItemName { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Length { get; set; }
        public double? LightItem { get; set; }
    }
}
