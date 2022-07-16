using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimCompensate
    {
        public string ClaimCompensateCode { get; set; }
        public string ClaimCompensateRuleCode { get; set; }
        public string ServiceCode { get; set; }
        public double? CustomerFreightPaid { get; set; }
        public double? CustomerReturnMoney { get; set; }
        public double? CompensateMoney { get; set; }
        public double? TotalCompensateMoneyPayCustomer { get; set; }
        public double? DamagedWeightPercent { get; set; }
        public double? DamagedOrLostWeight { get; set; }
        public double? TotalItemWeight { get; set; }
        public string CreatorName { get; set; }
        public string CreatorPOSCode { get; set; }
        public string CompensateReason { get; set; }
        public string AttachmentFile { get; set; }
        public string DecisionSigner { get; set; }
        public DateTime? DecisionDate { get; set; }
        public string PaidPOSCode { get; set; }
        public DateTime? PaidDate { get; set; }
        public string PaidPerson { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsRevoke { get; set; }
        public string ClaimNumber { get; set; }
        public string ReceivingClaimPOSCode { get; set; }
        public bool? IsDomestic { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string HandlerName { get; set; }
        public string HandlerPOSCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual Claim Claim { get; set; }
        public virtual ClaimCompensateRule ClaimCompensateRule { get; set; }
    }
}
