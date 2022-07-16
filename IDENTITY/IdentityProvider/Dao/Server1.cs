using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Server1
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public DateTime LastHeartbeat { get; set; }
    }
}
