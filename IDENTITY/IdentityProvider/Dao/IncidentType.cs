using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class IncidentType
    {
        public IncidentType()
        {
            Incident = new HashSet<Incident>();
            IncidentCategoryType = new HashSet<IncidentCategoryType>();
        }

        public byte ID { get; set; }
        public string IncidentTypeName { get; set; }

        public virtual ICollection<Incident> Incident { get; set; }
        public virtual ICollection<IncidentCategoryType> IncidentCategoryType { get; set; }
    }
}
