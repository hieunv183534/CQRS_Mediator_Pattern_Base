using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class View_TraceItemLast
    {
        public long ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemCodeCustomer { get; set; }
        public string ItemTypeCode { get; set; }
        public string ItemTypeName { get; set; }
        public double? Weight { get; set; }
        public string AcceptancePOSCode { get; set; }
        public string SenderCustomerCode { get; set; }
        public string SenderFullName { get; set; }
        public string ReceiverCustomerCode { get; set; }
        public string ReceiverCustomerName { get; set; }
        public string ReceiverCustomerAddress { get; set; }
        public string ReceiverFullName { get; set; }
        public string ReceiverProvinceCode { get; set; }
        public string ReceiverProvinceName { get; set; }
        public string ReceiverDistrictName { get; set; }
        public string DestinationPOSCode { get; set; }
        public string ServiceCode { get; set; }
        public long TraceItemID { get; set; }
        public string POSCode { get; set; }
        public bool Internal { get; set; }
        public bool InternalUpdated { get; set; }
        public byte? AcceptedStatus { get; set; }
        public byte Status { get; set; }
    }
}
