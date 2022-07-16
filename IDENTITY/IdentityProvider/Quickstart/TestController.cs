using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProvider.Quickstart
{
    [AllowAnonymous]
    public class TestController : Controller
    {
        DateTime nowww = DateTime.Now;

        public string Index()
        {
            var value = "";

            var code = new Google.Authenticator.TwoFactorAuthenticator();
            value = code.GetCurrentPIN("abcd1234567abcdd", nowww, false);

            return value;
        }
    }
}
