using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class UndeliveryGuide
    {
        public UndeliveryGuide()
        {
            Item = new HashSet<Item>();
            RangeUndeliveryGuide = new HashSet<RangeUndeliveryGuide>();
            RequestAcceptedDetail = new HashSet<RequestAcceptedDetail>();
        }

        public byte UndeliveryGuideCode { get; set; }
        public string UndeliveryGuideName { get; set; }

        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<RangeUndeliveryGuide> RangeUndeliveryGuide { get; set; }
        public virtual ICollection<RequestAcceptedDetail> RequestAcceptedDetail { get; set; }
    }
}
