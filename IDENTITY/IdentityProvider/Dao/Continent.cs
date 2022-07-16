using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Continent
    {
        public Continent()
        {
            Country = new HashSet<Country>();
        }

        public string ContinentCode { get; set; }
        public string ContinentName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Country> Country { get; set; }
    }
}
