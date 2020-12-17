using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolarEnergySystem.Infrastructure;
using SolarEnergySystem.API.Models;
using SolarEnergySystem.Core.Interfaces;
using SolarEnergySystem.Core.Enums;

namespace SolarEnergySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanelsController : ControllerBase
    {

        private readonly IPanelService _panelService;

        public PanelsController(IPanelService panelService)
        {
            _panelService = panelService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<PanelDto>> GetPanelsByDescendingOrder()
        {
            var ServiceResult = _panelService.GetPanelsByDescedingOrder();
            if (ServiceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(ServiceResult.Error);

            return Ok(ServiceResult.Result.Select(p => new PanelDto
            {
                NumeroDeSerie = p.Id,
                Type = p.PanelType,
                Unit = p.MeasuringUnit
            }));
        }
    }
}
