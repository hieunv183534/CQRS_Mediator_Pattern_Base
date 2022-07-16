using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RequestAcceptedDetail
    {
        public long RequestDetailID { get; set; }
        public long RequestID { get; set; }
        public string DeliveryPointCustomerCode { get; set; }
        public string DeliveryPointCode { get; set; }
        public string DeliveryPointName { get; set; }
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
        public string ItemCodeCustomer { get; set; }
        public string ItemTypeCode { get; set; }
        public DateTime? TimerDelivery { get; set; }
        public double? Weight { get; set; }
        public byte? UndeliveryGuideCode { get; set; }
        public int? RequestIndex { get; set; }
        public bool? Special { get; set; }
        public string AttachFile { get; set; }
        public string Note { get; set; }
        public byte? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public string VPostCode { get; set; }

        public virtual ItemType ItemTypeCodeNavigation { get; set; }
        public virtual RequestAccepted Request { get; set; }
        public virtual UndeliveryGuide UndeliveryGuideCodeNavigation { get; set; }
    }
}
