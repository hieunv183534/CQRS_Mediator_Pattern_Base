using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DeliveryRoutePoint
    {
        public string DeliveryRouteCode { get; set; }
        public string FromPOSCode { get; set; }
        public string DeliveryPointCode { get; set; }
        public string CustomerCode { get; set; }
        public byte? Order { get; set; }

        public virtual DeliveryPoint DeliveryPoint { get; set; }
        public virtual DeliveryRoute DeliveryRoute { get; set; }
    }
}
