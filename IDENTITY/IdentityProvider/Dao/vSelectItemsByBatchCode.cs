using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class vSelectItemsByBatchCode
    {
        public string ItemCode { get; set; }
        public string AcceptancePOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool? IsDeliverable { get; set; }
        public string AcceptancePOSName { get; set; }
        public string DeliveryPOSName { get; set; }
    }
}
