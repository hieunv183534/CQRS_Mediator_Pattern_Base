using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DeductionDetail
    {
        public string DeductionDetailCode { get; set; }
        public string DeductionCode { get; set; }
        public int? DeductionType { get; set; }
        public double? DeductionValue { get; set; }
        public int? DeductionByUnit { get; set; }
        public double? FromUnit { get; set; }
        public double? ToUnit { get; set; }
        public double? MinimumFeedback { get; set; }
        public double? MaximumFeedback { get; set; }
        public string ItemType { get; set; }
        public int? ConditionByUnit { get; set; }

        public virtual Deduction DeductionCodeNavigation { get; set; }
        public virtual ItemType ItemTypeNavigation { get; set; }
    }
}
