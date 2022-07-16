using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Mobile_View_DuongThu
    {
        public long MailtripID { get; set; }
        public string POSCode { get; set; }
        public string DeliveryRouteCode { get; set; }
        public string DeliveryRouteName { get; set; }
        public int MailtripNumber { get; set; }
        public int? Status { get; set; }
        public string MailtripDate { get; set; }
        public int? Quantity { get; set; }
    }
}
