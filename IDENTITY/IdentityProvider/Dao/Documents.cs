using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Documents
    {
        public long ID { get; set; }
        public string POSCode { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? DateCreated { get; set; }
        public string URL { get; set; }
    }
}
