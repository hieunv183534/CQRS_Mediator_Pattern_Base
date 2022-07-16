using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailRouteType
    {
        public MailRouteType()
        {
            MailRoute = new HashSet<MailRoute>();
        }

        public string MailRouteTypeCode { get; set; }
        public string MailRouteTypeName { get; set; }
        public string Description { get; set; }
        public string MailRouteTypeNameSearch { get; set; }

        public virtual ICollection<MailRoute> MailRoute { get; set; }
    }
}
