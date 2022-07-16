using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class SMS
    {
        public int ID { get; set; }
        public string PhoneNumber { get; set; }
        public string MessageContent { get; set; }
        public int? Status { get; set; }
        public int? MtID { get; set; }
        public DateTime? SendingTime { get; set; }
    }
}
