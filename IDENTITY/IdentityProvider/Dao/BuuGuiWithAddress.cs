using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BuuGuiWithAddress
    {
        public long ItemID { get; set; }
        public string SenderInfor { get; set; }
        public string ItemTypeName { get; set; }
        public string ItemTypeCode { get; set; }
        public string ItemCode { get; set; }
        public string ReceiverInfor { get; set; }
        public string ItemCodeCustomer { get; set; }
        public string DeliveryPointName { get; set; }
        public string DeliveryPointCode { get; set; }
        public string SenderCustomerCode { get; set; }
        public string SenderCustomerName { get; set; }
        public string ReceiverCustomerCode { get; set; }
        public string ReceiverCustomerName { get; set; }
    }
}
