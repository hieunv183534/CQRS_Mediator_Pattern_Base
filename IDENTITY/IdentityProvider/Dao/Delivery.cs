using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Delivery
    {
        public long ItemID { get; set; }
        public int DeliveryIndex { get; set; }
        public string ToPOSCode { get; set; }
        public string ItemCode { get; set; }
        public string CauseCode { get; set; }
        public string SolutionCode { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryCertificateName { get; set; }
        public string DeliveryCertificateNumber { get; set; }
        public DateTime? DeliveryCertificateDateOfIssue { get; set; }
        public string DeliveryCertificatePlaceOfIssue { get; set; }
        public bool? IsDeliverable { get; set; }
        public string DeliveryNote { get; set; }
        public string RealReciverName { get; set; }
        public string RealReceiverIdentification { get; set; }
        public string DeliveryMachine { get; set; }
        public string DeliveryUser { get; set; }
        public string InputingUser { get; set; }
        public double? ReturningMoney { get; set; }
        public DateTime? ReturningMoneyDate { get; set; }
        public double? CollectionMoney { get; set; }
        public DateTime? CollectionMoneyDate { get; set; }
        public string TransferMachine { get; set; }
        public string TransferUser { get; set; }
        public string TransferPOSCode { get; set; }
        public DateTime? TransferDate { get; set; }
        public bool? TransferStatus { get; set; }
        public int? TransferTimes { get; set; }
        public DateTime? InputDate { get; set; }
        public bool? SendMailSuccess { get; set; }
        public DateTime? SendMailDate { get; set; }
        public bool? SendSMSSuccess { get; set; }
        public DateTime? SendSMSDate { get; set; }
        public double? CODAmount { get; set; }
        public double? CODFreight { get; set; }
        public double? PostageFreight { get; set; }
        public double? AddedFreight { get; set; }
        public double? ReturnFreight { get; set; }
        public double? OtherFreight { get; set; }
        public string DeliveryCertificateOtherName { get; set; }
        public string ObjectTransfer { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public bool? DeliveryReturn { get; set; }
        public int? HandoverIndex { get; set; }
        public string ShiftCode { get; set; }
        public string CounterCode { get; set; }
        public string POSCode { get; set; }
        public string PostmanCode { get; set; }
        public string PostmanName { get; set; }
        public string DeliveryRouteCode { get; set; }
        public string DeliveryRouteName { get; set; }
        public long? MailtripID { get; set; }
        public string DeliveryPointReceiverCode { get; set; }
        public string DeliveryPointCode { get; set; }
        public string CustomerCode { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public string Image { get; set; }
        public bool? IsConfirm { get; set; }
        public bool? IsLast { get; set; }
        public string NextLast { get; set; }
        public bool? IsComplete { get; set; }
        public bool? IsFirst { get; set; }
        public bool? IsFinal { get; set; }

        public virtual Item Item { get; set; }
    }
}
