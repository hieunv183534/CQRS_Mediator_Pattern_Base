using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Claim
    {
        public Claim()
        {
            ClaimCompensate = new HashSet<ClaimCompensate>();
            ClaimItem = new HashSet<ClaimItem>();
            ClaimReply = new HashSet<ClaimReply>();
            ClaimResponse = new HashSet<ClaimResponse>();
        }

        public string ClaimNumber { get; set; }
        public string RecevingClaimPOSCode { get; set; }
        public DateTime ClaimTime { get; set; }
        public DateTime? ClaimReceivingTime { get; set; }
        public string ClaimPersonName { get; set; }
        public string ClaimPersonTel { get; set; }
        public string ClaimPersonEmail { get; set; }
        public string ClaimPersonAddress { get; set; }
        public string HeadOfRecevingUnit { get; set; }
        public byte? Status { get; set; }
        public string ClaimContent { get; set; }
        public DateTime? ClosingTime { get; set; }
        public string ClosingUser { get; set; }
        public bool? IsBigCustomer { get; set; }
        public string ClaimPriorityCode { get; set; }
        public string AttachmentFileName { get; set; }
        public string ClaimTypeCode { get; set; }
        public int? ClaimAnswerMethodCode { get; set; }
        public int? ClaimDirectionCode { get; set; }
        public DateTime? OpeningTime { get; set; }
        public string OpeningUser { get; set; }
        public string OpeningReason { get; set; }
        public string Notes { get; set; }
        public bool? IsCallCenter { get; set; }
        public bool? IsFullInfo { get; set; }
        public string ClaimCreator { get; set; }
        public bool? IsClose { get; set; }
        public string ResolveClaimPosCode { get; set; }
        public bool? IsClaimDomestic { get; set; }
        public string CN08Code { get; set; }
        public DateTime? ClaimDateExpired { get; set; }
        public string ClaimTypeOther { get; set; }
        public string BigCustomerCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual ClaimAnswerMethod ClaimAnswerMethodCodeNavigation { get; set; }
        public virtual ClaimDirection ClaimDirectionCodeNavigation { get; set; }
        public virtual ClaimPriority ClaimPriorityCodeNavigation { get; set; }
        public virtual ClaimType ClaimTypeCodeNavigation { get; set; }
        public virtual ClaimStatus StatusNavigation { get; set; }
        public virtual ICollection<ClaimCompensate> ClaimCompensate { get; set; }
        public virtual ICollection<ClaimItem> ClaimItem { get; set; }
        public virtual ICollection<ClaimReply> ClaimReply { get; set; }
        public virtual ICollection<ClaimResponse> ClaimResponse { get; set; }
    }
}
