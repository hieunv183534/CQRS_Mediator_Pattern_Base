using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class AffairHistory
    {
        public int AffairHistoryId { get; set; }
        public int AffairIndex { get; set; }
        public string ItemCode { get; set; }
        public string HistoryContent { get; set; }
        public string HistoryCreator { get; set; }
        public string HistoryCreatedPOS { get; set; }
        public DateTime HistoryCreatedDate { get; set; }
        public string BatchCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
