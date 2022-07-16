using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DeliveryScoping
    {
        public string DeliveryRouteCode { get; set; }
        public string FromPOSCode { get; set; }
        public string ServiceCode { get; set; }
        public string CommuneCode { get; set; }
        public int? DeliveryOrder { get; set; }

        public virtual Commune CommuneCodeNavigation { get; set; }
        public virtual DeliveryRouteService DeliveryRouteService { get; set; }
    }
}
