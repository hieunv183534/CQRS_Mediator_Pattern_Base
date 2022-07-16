using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MessageTypeLastCall
    {
        public string POSCode { get; set; }
        public DateTime? LastCall { get; set; }
        public string MessageTypeName { get; set; }
    }
}
