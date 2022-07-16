using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class AffairMessagePOS
    {
        public int AffairMessagePOSId { get; set; }
        public int Parent_AffairMessageId { get; set; }
        public int AffairMessageId { get; set; }
        public string FromPosCode { get; set; }
        public string ToPosCode { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsReplied { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public DateTime? CreateTime { get; set; }

        public virtual AffairMessage AffairMessage { get; set; }
    }
}
