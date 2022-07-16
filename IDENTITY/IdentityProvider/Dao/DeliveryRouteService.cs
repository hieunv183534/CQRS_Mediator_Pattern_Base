using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DeliveryRouteService
    {
        public DeliveryRouteService()
        {
            DeliveryScoping = new HashSet<DeliveryScoping>();
        }

        public string DeliveryRouteCode { get; set; }
        public string FromPOSCode { get; set; }
        public string ServiceCode { get; set; }

        public virtual DeliveryRoute DeliveryRoute { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
        public virtual ICollection<DeliveryScoping> DeliveryScoping { get; set; }
    }
}
