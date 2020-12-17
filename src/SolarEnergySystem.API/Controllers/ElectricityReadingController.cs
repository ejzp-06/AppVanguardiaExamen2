using Microsoft.AspNetCore.Mvc;
using SolarEnergySystem.API.Models;
using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Enums;
using SolarEnergySystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarEnergySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElectricityReadingController : Controller
    {
        private readonly IElectricityReadingService _electricityReadingService;

        public ElectricityReadingController(IElectricityReadingService electricityReadingService)
        {
            _electricityReadingService = electricityReadingService;
        }


        [HttpPost]
        public ActionResult<ElectricityReadingDto> RegisterReading([FromBody]ElectricityReading electricityReading)
        {
            //.c
            if (electricityReading == null | electricityReading.KiloWatt <= 0)
                return BadRequest("Objeto nulo o valor incorrecto.");

            //.a
            electricityReading.ReadingDateTime = DateTime.UtcNow;

            //.b
            if (electricityReading.Panel.MeasuringUnit == MeasuringUnit.Watt)
                electricityReading.KiloWatt /= 1000;
            
            //.d
            var MostRecentReading = _electricityReadingService.GetRecentReadingByPanelId(electricityReading.PanelId);

            switch (electricityReading.Panel.PanelType)
            {
                case PanelType.Regular:
                    {
                        TimeSpan timeSpan = DateTime.UtcNow.Subtract(MostRecentReading.Result.ReadingDateTime);
                        if (timeSpan.Hours < 1)
                            return BadRequest("No se puede realizar la medición.");
                    }
                    break;

                case PanelType.Limited:
                    {
                        TimeSpan timeSpan = DateTime.UtcNow.Subtract(MostRecentReading.Result.ReadingDateTime);
                        if (timeSpan.Days < 1)
                            return BadRequest("No se puede realizar la medición.");
                    }
                    break;

                case PanelType.Ultimate:
                    {
                        TimeSpan timeSpan = DateTime.UtcNow.Subtract(MostRecentReading.Result.ReadingDateTime);
                        if (timeSpan.Minutes < 1)
                            return BadRequest("No se puede realizar la medición.");
                    }
                    break;

                default:
                    return BadRequest("Error indefinidio.");
            }

            var ServiceResult = _electricityReadingService.RegisterReading(electricityReading);
            if (ServiceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(ServiceResult.Error);

            var result = new ElectricityReadingDto
            {
                NumeroDeSerie = ServiceResult.Result.PanelId,
                Panel = ServiceResult.Result.Panel,
                KiloWatt = ServiceResult.Result.KiloWatt,
                ReadingDateTime = DateTime.UtcNow
            };

            return Ok(result);
        }
    }
}
