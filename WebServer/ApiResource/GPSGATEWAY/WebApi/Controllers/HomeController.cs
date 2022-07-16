using NOM.GPSGATEWAY.Domain.Application.SynData.Commands;
using NOM.GPSGATEWAY.WebApi.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.GPSGATEWAY.WebApi.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }


        [HttpPost]
        public async Task<long> SynData([FromBody] UpdateCommand request)
        {
            return await Mediator.Send(request);
        }
    }
}
