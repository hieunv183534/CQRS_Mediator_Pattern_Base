using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Section
    {
        public string SectionCode { get; set; }
        public string POSCode { get; set; }
        public string SectionName { get; set; }
        public string Description { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
    }
}
