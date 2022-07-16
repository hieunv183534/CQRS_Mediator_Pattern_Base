using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BD21Disscusion
    {
        public DateTime CreatedDate { get; set; }
        public string MailtripPOS { get; set; }
        public string BC43Code { get; set; }
        public string FromPosCode { get; set; }
        public string DisscusionContent { get; set; }
        public string ReplyUser { get; set; }
        public string AttachmentFileName { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
