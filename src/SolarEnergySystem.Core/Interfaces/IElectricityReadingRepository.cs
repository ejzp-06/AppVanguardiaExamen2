using SolarEnergySystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarEnergySystem.Core.Interfaces
{
    public interface IElectricityReadingRepository
    {
        ElectricityReading RegisterReding(ElectricityReading electricityReading);

        ElectricityReading GetRecentReadingByPanelId(string panelId);
    }
}
