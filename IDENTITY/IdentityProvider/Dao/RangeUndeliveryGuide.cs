using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RangeUndeliveryGuide
    {
        public string RangeCode { get; set; }
        public byte UndeliveryGuideCode { get; set; }

        public virtual Range RangeCodeNavigation { get; set; }
        public virtual UndeliveryGuide UndeliveryGuideCodeNavigation { get; set; }
    }
}
