using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ShiftHandoverItem
    {
        public long ShiftHandoverID { get; set; }
        public long ItemID { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string TableName { get; set; }
        public long? TableID { get; set; }
        public DateTime? ShiftHandoverTime { get; set; }
        public string ShiftHandoverDate { get; set; }
        public string ShiftHandoverMonth { get; set; }
        public int? ShiftHandoverYear { get; set; }
        public int? IndexNumber { get; set; }

        public virtual Item Item { get; set; }
        public virtual ShiftHandover ShiftHandover { get; set; }
    }
}
