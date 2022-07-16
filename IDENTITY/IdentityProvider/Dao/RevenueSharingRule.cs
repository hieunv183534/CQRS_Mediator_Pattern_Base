using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RevenueSharingRule
    {
        public RevenueSharingRule()
        {
            DeliveryRevenueSharing = new HashSet<DeliveryRevenueSharing>();
        }

        public string RevenueSharingRuleCode { get; set; }
        public string ServiceCode { get; set; }
        public DateTime ValueDate { get; set; }
        public string RuleNumber { get; set; }
        public double? CollectionFreightPercent { get; set; }
        public double? PaymentFreightPercent { get; set; }
        public double? AcceptancePercent { get; set; }

        public virtual Service ServiceCodeNavigation { get; set; }
        public virtual ICollection<DeliveryRevenueSharing> DeliveryRevenueSharing { get; set; }
    }
}
