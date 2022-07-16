using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class TransportType
    {
        public TransportType()
        {
            MailRoute = new HashSet<MailRoute>();
            WholeQualityTarget = new HashSet<WholeQualityTarget>();
        }

        public string TransportTypeCode { get; set; }
        public string TransportTypeName { get; set; }
        public string Description { get; set; }
        public string TransportTypeNameSearch { get; set; }

        public virtual ICollection<MailRoute> MailRoute { get; set; }
        public virtual ICollection<WholeQualityTarget> WholeQualityTarget { get; set; }
    }
}
