using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProvider.Quickstart.Account
{
    public class AccountModel
    {
        public string Username { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ClientSecrets { get; set; }

    }

    public class LockAccountModel
    {
        public string Username { get; set; }
        public string ClientSecrets { get; set; }

        public int AccessFailedCount
        {
            get
            {
                return LockoutEnabled ? 100 : 0;
            }
        }

        public DateTime? LockoutEnd
        {
            get
            {
                if (LockoutEnabled) {
                    return DateTime.Now.AddYears(1000);
                }


                return null;
            }
        }
        public bool LockoutEnabled { get; set; }

    }
}
