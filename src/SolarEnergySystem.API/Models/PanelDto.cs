using SolarEnergySystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarEnergySystem.API.Models
{
    public class PanelDto
    { 

        public string NumeroDeSerie { get; set; }

        public MeasuringUnit Unit { get; set; }

        public PanelType Type { get; set; }

    }
}
