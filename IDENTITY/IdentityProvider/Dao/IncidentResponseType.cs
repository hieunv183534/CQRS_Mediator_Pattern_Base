using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class IncidentResponseType
    {
        public IncidentResponseType()
        {
            Incident = new HashSet<Incident>();
        }

        public byte ID { get; set; }
        public string ResponseType { get; set; }

        public virtual ICollection<Incident> Incident { get; set; }
    }
}
