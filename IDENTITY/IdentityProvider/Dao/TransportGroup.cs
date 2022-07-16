using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class TransportGroup
    {
        public TransportGroup()
        {
            Transport = new HashSet<Transport>();
        }

        public string TransportGroupCode { get; set; }
        public string TransportGroupName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Transport> Transport { get; set; }
    }
}
