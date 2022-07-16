using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RangeServiceItemType
    {
        public string RangeCode { get; set; }
        public string ServiceCode { get; set; }
        public string ItemTypeCode { get; set; }

        public virtual Range RangeCodeNavigation { get; set; }
        public virtual ServiceItemType ServiceItemType { get; set; }
    }
}
