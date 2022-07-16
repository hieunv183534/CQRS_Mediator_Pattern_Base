using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DeliveryPoint
    {
        public DeliveryPoint()
        {
            DeliveryPointReceiver = new HashSet<DeliveryPointReceiver>();
            DeliveryRoutePoint = new HashSet<DeliveryRoutePoint>();
            ObjectReceiver = new HashSet<ObjectReceiver>();
        }

        public string DeliveryPointCode { get; set; }
        public string CustomerCode { get; set; }
        public string DeliveryPointName { get; set; }
        public string DeliveryPointAddress { get; set; }
        public string ProvinceCode { get; set; }
        public string DistrictCode { get; set; }
        public string CommuneCode { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public string POSCode { get; set; }
        public string DeliveryPointNameSearch { get; set; }
        public string VMapCode { get; set; }
        public long? ObjectId { get; set; }
        public double? Order { get; set; }

        public virtual Customer CustomerCodeNavigation { get; set; }
        public virtual CustomerObject Object { get; set; }
        public virtual ICollection<DeliveryPointReceiver> DeliveryPointReceiver { get; set; }
        public virtual ICollection<DeliveryRoutePoint> DeliveryRoutePoint { get; set; }
        public virtual ICollection<ObjectReceiver> ObjectReceiver { get; set; }
    }
}
