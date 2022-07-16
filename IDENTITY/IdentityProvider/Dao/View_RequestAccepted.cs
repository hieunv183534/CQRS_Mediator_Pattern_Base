using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class View_RequestAccepted
    {
        public string ShiftCode { get; set; }
        public DateTime StartTime { get; set; }
        public string ShiftName { get; set; }
        public long ShiftHandoverID { get; set; }
        public long RequestID { get; set; }
        public string RequestCode { get; set; }
        public string POSCode { get; set; }
        public DateTime RequestDate { get; set; }
        public int RequestType { get; set; }
        public int? RequestAcceptedType { get; set; }
        public string SenderCustomerCode { get; set; }
        public string SenderFullName { get; set; }
        public string SenderProvinceCode { get; set; }
        public string SenderDistrictCode { get; set; }
        public string SenderCommuneCode { get; set; }
        public string SenderAddress { get; set; }
        public string SenderTel { get; set; }
        public string SenderEmail { get; set; }
        public string SenderFax { get; set; }
        public string SenderTaxCode { get; set; }
        public string SenderIdentifyNumber { get; set; }
        public long? SenderObjectID { get; set; }
        public int? ItemNumber { get; set; }
        public int? ItemNumberPostman { get; set; }
        public int? ItemNumberTellers { get; set; }
        public int? ItemNumberSecret { get; set; }
        public int? ItemNumberSecretPostman { get; set; }
        public int? ItemNumberSecretTellers { get; set; }
        public int? ItemNumberPrioritize { get; set; }
        public int? ItemNumberPrioritizePostman { get; set; }
        public int? ItemNumberPrioritizeTellers { get; set; }
        public string RequestContent { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedContent { get; set; }
        public DateTime? PostmanApprovedDate { get; set; }
        public string PostmanApprovedBy { get; set; }
        public string PostmanApprovedContent { get; set; }
        public DateTime? TellersApprovedDate { get; set; }
        public string TellersApprovedBy { get; set; }
        public string TellersApprovedContent { get; set; }
        public long? ParentId { get; set; }
        public string ReceiverCustomerCode { get; set; }
        public string ReceiverCustomerName { get; set; }
        public string ReceiverCustomerAddress { get; set; }
        public string ReceiverCustomerTel { get; set; }
        public string ReceiverFullName { get; set; }
        public string ReceiverProvinceCode { get; set; }
        public string ReceiverDistrictCode { get; set; }
        public string ReceiverCommuneCode { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverTel { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverFax { get; set; }
        public string ReceiverTaxCode { get; set; }
        public string ReceiverIdentifyNumber { get; set; }
        public string ReceiverContact { get; set; }
        public long? ReceiverObjectID { get; set; }
        public double? ReceiverLat { get; set; }
        public double? ReceiverLong { get; set; }
        public double? SenderLat { get; set; }
        public double? SenderLong { get; set; }
        public double? DeliveryLat { get; set; }
        public double? DeliveryLong { get; set; }
        public string AttachFile { get; set; }
        public string ReceiverPOSCode { get; set; }
    }
}
