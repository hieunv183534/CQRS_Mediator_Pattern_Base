using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BD21AffairResponse
    {
        public string AffairResponseNumber { get; set; }
        public string BC43Code { get; set; }
        public string FromPOSCode { get; set; }
        public string BD10FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public DateTime? SendingTime { get; set; }
        public DateTime? ReceivingTime { get; set; }
        public bool? IsReceived { get; set; }
        public string ReasonNotAccept { get; set; }
        public DateTime? SentBackTime { get; set; }
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
        public int? AffairResultCode { get; set; }
        public string AffairResultContent { get; set; }
        public string AttachmentFile { get; set; }
        public string AttachmentFileReply { get; set; }
        public bool? IsCompensate { get; set; }
        public DateTime? ResponseDateExpired { get; set; }
        public byte? POSOrder { get; set; }
        public string OtherBD10Code { get; set; }
        public bool? IsViewed { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual BC43 BC43 { get; set; }
    }
}
