using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Order
    {
        public Order()
        {
            Batch = new HashSet<Batch>();
        }

        public string OrderCode { get; set; }
        public string POSCode { get; set; }
        public string CustomerCode { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? MainFreight { get; set; }
        public double? Discount { get; set; }
        public double? Abatement { get; set; }
        public double? TotalFreight { get; set; }
        public string Content { get; set; }
        public byte? Status { get; set; }

        public virtual Customer CustomerCodeNavigation { get; set; }
        public virtual ICollection<Batch> Batch { get; set; }
    }
}
