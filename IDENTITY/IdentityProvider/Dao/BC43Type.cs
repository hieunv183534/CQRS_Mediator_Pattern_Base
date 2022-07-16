using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BC43Type
    {
        public BC43Type()
        {
            BC43 = new HashSet<BC43>();
        }

        public int BC43Type1 { get; set; }
        public string BC43TypeName { get; set; }
        public string BC43Description { get; set; }
        public int? BC43Category { get; set; }

        public virtual ICollection<BC43> BC43 { get; set; }
    }
}
