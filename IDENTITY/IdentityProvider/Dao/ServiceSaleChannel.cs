using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ServiceSaleChannel
    {
        public string ServiceCode { get; set; }
        public string SaleChannelCode { get; set; }

        public virtual SaleChannel SaleChannelCodeNavigation { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
    }
}
