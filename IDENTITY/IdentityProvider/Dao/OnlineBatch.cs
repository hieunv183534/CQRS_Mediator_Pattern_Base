using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class OnlineBatch
    {
        public string BatchCode { get; set; }
        public string CustomerCode { get; set; }
        public double? MainFreight { get; set; }
        public double? Discount { get; set; }
        public double? Abatement { get; set; }
        public double? TotalFreight { get; set; }
        public string OrderCode { get; set; }

        public virtual OnlineOrder OnlineOrder { get; set; }
    }
}
