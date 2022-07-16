using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ActivityLogType
    {
        public int ActivityLogTypeId { get; set; }
        public string ActionKeyword { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
