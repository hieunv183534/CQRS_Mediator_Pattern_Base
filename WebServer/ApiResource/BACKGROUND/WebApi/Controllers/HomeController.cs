using NOM.BACKGROUND.Domain.Interfaces;
using NOM.BACKGROUND.WebApi.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOM.BACKGROUND.WebApi.Controllers
{
    public class HomeController : ApiController
    {


        public HomeController()
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public string Index()
        {
            return "ok";
        }
    }
}
