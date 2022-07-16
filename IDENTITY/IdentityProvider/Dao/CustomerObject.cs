using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class CustomerObject
    {
        public CustomerObject()
        {
            DeliveryPoint = new HashSet<DeliveryPoint>();
        }

        public long ObjectID { get; set; }
        public string CustomerCode { get; set; }
        public byte ObjectType { get; set; }
        public string ObjectCode { get; set; }
        public string ObjectName { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public bool? AllowSend { get; set; }
        public bool? AllowReceiver { get; set; }

        public virtual Customer CustomerCodeNavigation { get; set; }
        public virtual ICollection<DeliveryPoint> DeliveryPoint { get; set; }
    }
}
