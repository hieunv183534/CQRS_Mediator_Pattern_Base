using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Incident
    {
        public Incident()
        {
            IncidentItem = new HashSet<IncidentItem>();
            IncidentPostbag = new HashSet<IncidentPostbag>();
        }

        public long IncidentID { get; set; }
        public string IncidentCode { get; set; }
        public byte? IncidentCataloge { get; set; }
        public byte? IncidentType { get; set; }
        public DateTime? IncidentDate { get; set; }
        public byte? IncidentStatus { get; set; }
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public string IncidentContent { get; set; }
        public long? ExternalID { get; set; }
        public DateTime? ResponseDate { get; set; }
        public byte? ResponseType { get; set; }
        public string ResponseContent { get; set; }
        public string UsernameCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastModified { get; set; }
        public string UsernameResponse { get; set; }
        public string URLFile { get; set; }
        public double? Freight { get; set; }

        public virtual IncidentCategory IncidentCatalogeNavigation { get; set; }
        public virtual IncidentType IncidentTypeNavigation { get; set; }
        public virtual IncidentResponseType ResponseTypeNavigation { get; set; }
        public virtual ICollection<IncidentItem> IncidentItem { get; set; }
        public virtual ICollection<IncidentPostbag> IncidentPostbag { get; set; }
    }
}
