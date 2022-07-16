using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RateUser
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string RateMonth { get; set; }
        public int? RateLevel { get; set; }
        public string RateDesc { get; set; }

        public virtual User UserNameNavigation { get; set; }
    }
}
