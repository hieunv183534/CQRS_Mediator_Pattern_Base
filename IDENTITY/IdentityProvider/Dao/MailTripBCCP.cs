using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailTripBCCP
    {
        public string StartingCode { get; set; }
        public string DestinationCode { get; set; }
        public int MailtripType { get; set; }
        public string ServiceCode { get; set; }
        public string Year { get; set; }
        public int MailtripNumber { get; set; }
    }
}
