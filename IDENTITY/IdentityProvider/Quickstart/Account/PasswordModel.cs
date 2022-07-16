using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProvider.Quickstart.Account
{
    public class PasswordModel
    {
        public class ResetPasswordModel
        {
            public string ClientSecrets { get; set; }

            public string UserName { get; set; }

            public string PasswordOld { get; set; }

            public string Password { get; set; }
        }
    }
}
