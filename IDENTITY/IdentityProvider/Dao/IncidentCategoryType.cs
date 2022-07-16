using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class IncidentCategoryType
    {
        public byte IncidentCategoryID { get; set; }
        public byte IncidentTypeID { get; set; }

        public virtual IncidentCategory IncidentCategory { get; set; }
        public virtual IncidentType IncidentType { get; set; }
    }
}
