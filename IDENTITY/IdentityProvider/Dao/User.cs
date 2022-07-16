using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class User
    {
        public User()
        {
            RateUser = new HashSet<RateUser>();
        }

        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool? Sex { get; set; }
        public string Mobile { get; set; }
        public string Tel { get; set; }
        public string POSCode { get; set; }
        public string PassWord { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public bool? IsFromAD { get; set; }
        public bool? IsPOSAdmin { get; set; }
        public string UnitCode { get; set; }
        public string CustomerCode { get; set; }
        public string AreaPos { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
        public virtual ICollection<RateUser> RateUser { get; set; }
    }
}
