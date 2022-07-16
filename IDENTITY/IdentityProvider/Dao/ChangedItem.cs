using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ChangedItem
    {
        public long ItemID { get; set; }
        public int ItemChangedIndex { get; set; }
        public string ItemCode { get; set; }
        public string ItemCodeOld { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ChangedDate { get; set; }
    }
}
