using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BD21History
    {
        public string HistoryId { get; set; }
        public string BD21Code { get; set; }
        public int? BD21Type { get; set; }
        public string RelateCode { get; set; }
        public string HistoryContent { get; set; }
        public string Creator { get; set; }
        public string CreatedPOS { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
