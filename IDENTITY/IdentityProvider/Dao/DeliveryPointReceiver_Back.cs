using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DeliveryPointReceiver_Back
    {
        public string DeliveryPointReceiverCode { get; set; }
        public string DeliveryPointCode { get; set; }
        public string CustomerCode { get; set; }
        public string ReceiverFullName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverDepartment { get; set; }
        public string ReceiverPosition { get; set; }
        public bool? Validated { get; set; }
    }
}
