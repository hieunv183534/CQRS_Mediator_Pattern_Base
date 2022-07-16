using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DeliveryRevenueSharing
    {
        public string DeliveryRevenueSharingCode { get; set; }
        public string RevenueSharingRuleCode { get; set; }
        public string ServiceCode { get; set; }
        public double? FromWeight { get; set; }
        public double? ToWeight { get; set; }
        public double? MoneyPerItem { get; set; }
        public double? WeightStep { get; set; }
        public double? MoneyStep { get; set; }

        public virtual RevenueSharingRule RevenueSharingRule { get; set; }
    }
}
