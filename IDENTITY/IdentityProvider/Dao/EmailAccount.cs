using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class EmailAccount
    {
        public int EmailID { get; set; }
        public string DisplayName { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public bool EnableSSL { get; set; }
        public int? Port { get; set; }
        public bool Enable { get; set; }
        public string MailAccount { get; set; }
    }
}
