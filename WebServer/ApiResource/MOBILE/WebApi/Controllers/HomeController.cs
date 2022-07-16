using NOM.MOBILE.WebApi.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOM.MOBILE.WebApi.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public string CheckStatus()
        {
            return "ok";
        }
    }
}
