using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class SaleChannel
    {
        public SaleChannel()
        {
            ServiceSaleChannel = new HashSet<ServiceSaleChannel>();
        }

        public string SaleChannelCode { get; set; }
        public string SaleChannelName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ServiceSaleChannel> ServiceSaleChannel { get; set; }
    }
}
