using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DeliveryRoute
    {
        public DeliveryRoute()
        {
            DeliveryRoutePoint = new HashSet<DeliveryRoutePoint>();
            DeliveryRouteService = new HashSet<DeliveryRouteService>();
        }

        public string DeliveryRouteCode { get; set; }
        public string FromPOSCode { get; set; }
        public string DeliverRouteName { get; set; }
        public string Description { get; set; }
        public string DeliveryRouteName { get; set; }
        public bool? OutOfWorkingTime { get; set; }
        public string DeliverRouteNameSearch { get; set; }
        public string ScopeType { get; set; }
        public bool? IsHide { get; set; }

        public virtual POS FromPOSCodeNavigation { get; set; }
        public virtual ICollection<DeliveryRoutePoint> DeliveryRoutePoint { get; set; }
        public virtual ICollection<DeliveryRouteService> DeliveryRouteService { get; set; }
    }
}
