using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class IncidentPostbag
    {
        public long IncidentID { get; set; }
        public long PostbagID { get; set; }
        public double? OldWeight { get; set; }
        public double? NewWeight { get; set; }
        public int? OldNumberItem { get; set; }
        public int? NewNumberItem { get; set; }

        public virtual Incident Incident { get; set; }
    }
}
