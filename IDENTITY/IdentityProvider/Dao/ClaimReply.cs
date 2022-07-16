using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimReply
    {
        public string ClaimReplyCode { get; set; }
        public string ClaimNumber { get; set; }
        public string ReceivingClaimPOSCode { get; set; }
        public string ReplyPOSCode { get; set; }
        public string ReplyContent { get; set; }
        public DateTime? ReplyDate { get; set; }
        public string ReplyUser { get; set; }
        public bool? IsPaidCompensate { get; set; }
        public string ServiceCode { get; set; }
        public string ClaimCompensateCode { get; set; }
        public string ClaimCompensateRuleCode { get; set; }
        public DateTime? ReplyDateExpired { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual Claim Claim { get; set; }
    }
}
