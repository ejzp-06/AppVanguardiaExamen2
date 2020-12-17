using SolarEnergySystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarEnergySystem.API.Models
{
    public class ElectricityReadingDto
    {
        public string NumeroDeSerie { get; set; }

        public Panel Panel { get; set; }

        public double KiloWatt { get; set; }

        public DateTime ReadingDateTime { get; set; }
    }
}
