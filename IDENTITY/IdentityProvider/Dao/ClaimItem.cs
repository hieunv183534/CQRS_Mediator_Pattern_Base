using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimItem
    {
        public string ClaimNumber { get; set; }
        public string RecevingClaimPOSCode { get; set; }
        public string ItemCode { get; set; }
        public long ItemID { get; set; }
        public string ServiceCode { get; set; }
        public string AcceptancePOSCode { get; set; }
        public DateTime? SendingTime { get; set; }
        public double? Weight { get; set; }
        public double? TotalFreight { get; set; }
        public string ItemTypeCode { get; set; }
        public bool? IsDomestic { get; set; }
        public string CountryCode { get; set; }
        public string ProvinceCode { get; set; }
        public string SenderFullname { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverFullname { get; set; }
        public string ReceiverAddress { get; set; }
        public bool? IsAirmail { get; set; }
        public double? VATFreight { get; set; }
        public double? VATPercentage { get; set; }
        public string ExchangeRateCode { get; set; }
        public string SendingContent { get; set; }
        public string SenderCode { get; set; }
        public string SenderMobile { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPosCode { get; set; }
        public string SenderTaxCode { get; set; }
        public string SenderTel { get; set; }
        public string SenderFax { get; set; }
        public string SenderIdentification { get; set; }
        public string SenderDistrictCode { get; set; }
        public string ReceiverMobile { get; set; }
        public string ReceiverTel { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverContact { get; set; }
        public string ReceiverAddressCode { get; set; }
        public string ReceiverTaxCode { get; set; }
        public string ReceiverIdentification { get; set; }
        public string ReceiverDistrictCode { get; set; }
        public bool? IsCN48 { get; set; }
        public bool? IsSentProvincePOSCode { get; set; }
        public DateTime? CN48CreatedDate { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public string Note { get; set; }
        public string ReceiverCommuneCode { get; set; }

        public virtual Claim Claim { get; set; }
        public virtual Item Item { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
    }
}
