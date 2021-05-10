using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWaverWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThirdlabCalculationController : ControllerBase
    {
        private readonly ILogger<ThirdlabCalculationController> _logger;
        private readonly ThirdlabCalculationService service;
        public ThirdlabCalculationController(ILogger<ThirdlabCalculationController> logger, ThirdlabCalculationService service)
        {
            this.service = service;
            _logger = logger;
        }

        [HttpGet("GetGraphData")]
        public async Task<IActionResult> GetGraphData()
        {
            return new JsonResult(await service.GetPlotPointsAsync());
        }

    }
}
