using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BC43Affair
    {
        public string BC43Code { get; set; }
        public string FromPosCode { get; set; }
        public string ToPosCode { get; set; }
        public string ReplyFromToPosCode { get; set; }
        public DateTime? ReplyDate { get; set; }
        public string ReplyPersonName { get; set; }
        public string LeaderOfToPosCode { get; set; }
        public bool? IsReplied { get; set; }
        public bool? IsClosed { get; set; }
        public bool? IsForwardedPosCode { get; set; }
        public string ResolveAffairPosCode { get; set; }
        public DateTime? ClosingDate { get; set; }
        public bool? IsViewed { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual BC43 BC43 { get; set; }
    }
}
