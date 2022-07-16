using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Version
    {
        public Version()
        {
            MenuVersion = new HashSet<MenuVersion>();
        }

        public string VersionCode { get; set; }
        public DateTime ReleasedDate { get; set; }
        public string ApplicationType { get; set; }
        public byte? Status { get; set; }

        public virtual ICollection<MenuVersion> MenuVersion { get; set; }
    }
}
