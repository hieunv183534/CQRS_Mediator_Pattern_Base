using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimResponse
    {
        public ClaimResponse()
        {
            ClaimResponseMailtrip = new HashSet<ClaimResponseMailtrip>();
        }

        public string ClaimResponseNumber { get; set; }
        public string ReceivingClaimPOSCode { get; set; }
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public string ClaimNumber { get; set; }
        public DateTime? SendingTime { get; set; }
        public DateTime? ReceivingTime { get; set; }
        public bool? IsReceived { get; set; }
        public string ReasonNotAccept { get; set; }
        public DateTime? SentBackTime { get; set; }
        public DateTime? TimeDue { get; set; }
        public string SendingUser { get; set; }
        public string ReceivingUser { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
        public bool? IsError { get; set; }
        public byte? Status { get; set; }
        public DateTime? AnswerDate { get; set; }
        public string AnswerUser { get; set; }
        public string AnswerAtRelatePos { get; set; }
        public bool? IsFinalAnswer { get; set; }
        public int? ClaimConclusionCode { get; set; }
        public string ClaimConclusionContent { get; set; }
        public int? ClaimResultCode { get; set; }
        public string ClaimResultContent { get; set; }
        public string AttachmentFile { get; set; }
        public bool? IsCompensate { get; set; }
        public int? ClaimTypeErrorCode { get; set; }
        public int? ClaimTransportUnitCode { get; set; }
        public DateTime? ResponseDateExpired { get; set; }
        public string ClaimTypeErrorOther { get; set; }
        public string ClaimTransportUnitOther { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual Claim Claim { get; set; }
        public virtual ClaimResult ClaimResultCodeNavigation { get; set; }
        public virtual ICollection<ClaimResponseMailtrip> ClaimResponseMailtrip { get; set; }
    }
}
