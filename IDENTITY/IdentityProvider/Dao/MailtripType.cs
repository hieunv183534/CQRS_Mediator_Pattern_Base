using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailtripType
    {
        public MailtripType()
        {
            Mailtrip = new HashSet<Mailtrip>();
        }

        public int MailtripTypeCode { get; set; }
        public string MailtripTypeName { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<Mailtrip> Mailtrip { get; set; }
    }
}
