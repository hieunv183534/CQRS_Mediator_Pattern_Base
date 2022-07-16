using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemType_MBCSync
    {
        public string ItemTypeCode { get; set; }
        public string ItemTypeName { get; set; }
        public string Description { get; set; }
        public int? OrderIndex { get; set; }
        public int? Type { get; set; }
    }
}
