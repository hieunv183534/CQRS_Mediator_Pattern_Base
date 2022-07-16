using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemReturn_Sync
    {
        public long? ItemID { get; set; }
        public string ItemCode { get; set; }
        public string Reason { get; set; }
        public double? Freight { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ReceiverFullname { get; set; }
        public string ReceiverTel { get; set; }
        public string ReceiverAddress { get; set; }
        public string CountryCode { get; set; }
        public bool? IsAirline { get; set; }
        public string POSCode { get; set; }
        public double? FreightVAT { get; set; }
        public int? ReturnType { get; set; }
        public int? ReturnLocation { get; set; }
        public int? AffairIndex { get; set; }
        public string Note { get; set; }
        public double? ReturnFreightCustomer { get; set; }
        public double? ReturnFreightVATCustomer { get; set; }
        public double? MainFreight { get; set; }
        public double? SubFreight { get; set; }
        public double? FuelSurchargeFreight { get; set; }
        public double? FarRegionFreight { get; set; }
        public double? AirSurchargeFreight { get; set; }
        public double? VATFreight { get; set; }
        public double? VATPercentage { get; set; }
        public double? OriginalMainFreight { get; set; }
        public double? OriginalSubFreight { get; set; }
        public double? OriginalFuelSurchargeFreight { get; set; }
        public double? OriginalFarRegionFreight { get; set; }
        public double? OriginalAirSurchargeFreight { get; set; }
        public double? OriginalVATFreight { get; set; }
        public double? OriginalVATPercentage { get; set; }
        public double? OriginalFreight { get; set; }
        public double? OriginalFreightVAT { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
