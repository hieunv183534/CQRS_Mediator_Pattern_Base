using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ObjectReceiver
    {
        public long ReceiverObjectID { get; set; }
        public string ReceiverObjectName { get; set; }
        public string DeliveryPointCode { get; set; }
        public string CustomerCode { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }

        public virtual DeliveryPoint DeliveryPoint { get; set; }
    }
}
