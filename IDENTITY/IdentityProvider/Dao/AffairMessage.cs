using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class AffairMessage
    {
        public AffairMessage()
        {
            AffairMessagePOS = new HashSet<AffairMessagePOS>();
        }

        public int AffairMessageId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public bool IsFinal { get; set; }
        public string AttachmentFileName { get; set; }
        public bool IsInitital { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public DateTime? CreateTime { get; set; }

        public virtual ICollection<AffairMessagePOS> AffairMessagePOS { get; set; }
    }
}
