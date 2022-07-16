using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class OnlineItem
    {
        public int ItemIndex { get; set; }
        public string ItemCode { get; set; }
        public string SenderFullname { get; set; }
        public string SenderAddress { get; set; }
        public string CustomerCode { get; set; }
        public string BatchCode { get; set; }
        public string ReceiverFullname { get; set; }
        public string ReceiverTel { get; set; }
        public string ReceiverAddress { get; set; }
        public bool? isDomestic { get; set; }
        public string CountryCode { get; set; }
        public string POSCode { get; set; }
        public bool? IsStatePrice { get; set; }
        public double? StatePriceValue { get; set; }
        public string SendingContent { get; set; }
        public string Note { get; set; }
        public string ItemTypeCode { get; set; }
        public DateTime? SendingTime { get; set; }
        public bool IsAirmail { get; set; }
        public double Weight { get; set; }
        public byte? Status { get; set; }
        public double TotalFreight { get; set; }
        public string EmployeeCode { get; set; }
        public string SenderJob { get; set; }
        public string ProvinceCode { get; set; }
        public double? LightItem { get; set; }
        public string SectionCode { get; set; }
        public string ReceiverJob { get; set; }
        public bool? IsOpened { get; set; }
        public string CertificateNumber { get; set; }
        public string LicenseNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string SenderIdentification { get; set; }
        public DateTime? SenderIssueDate { get; set; }
        public string SenderIssueCountry { get; set; }
        public string ReceiverIdentification { get; set; }
        public DateTime? ReceiverIssueDate { get; set; }
        public string ReceiverIssueCountry { get; set; }
        public string SenderTel { get; set; }
        public double? MainFreight { get; set; }
        public double? VATFreight { get; set; }
        public double? SubFreight { get; set; }
        public bool? IsPostFree { get; set; }
        public double? StatePriceFreight { get; set; }
        public int? PrintedNumber { get; set; }
        public string DataCode { get; set; }
        public string SenderCustomReference { get; set; }
        public double? RemainingFreight { get; set; }
        public string ReceiverCustomReference { get; set; }
        public bool? IsReturn { get; set; }
        public bool? IsCompensate { get; set; }
        public bool? IsForward { get; set; }
        public bool? IsAirmailForward { get; set; }
        public bool? IsAirmailReturn { get; set; }
        public bool? IsDebt { get; set; }
        public string MachineName { get; set; }
        public int? AcceptedIndex { get; set; }
        public int? BC16Index { get; set; }
        public int? IncomingIndex { get; set; }
        public string ServiceCode { get; set; }
        public string DistrictCode { get; set; }
        public double? LetterMoneyOrderFreight { get; set; }
        public double? ValueAddedServiceFreightTotalFreight { get; set; }
        public string OrderCode { get; set; }
        public string AddressCode { get; set; }
        public string SenderMobile { get; set; }
        public string SenderFax { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverMobile { get; set; }
        public string ReceiverFax { get; set; }
        public string ReceiverEmail { get; set; }
        public double? Discount { get; set; }
        public double? Abatement { get; set; }
        public byte? UndeliverableGuide { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Length { get; set; }
        public string CheckSum { get; set; }
        public string ItemNumber { get; set; }
        public string ExchangeRateCode { get; set; }
    }
}
