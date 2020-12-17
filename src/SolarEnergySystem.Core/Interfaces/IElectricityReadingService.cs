using SolarEnergySystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarEnergySystem.Core.Interfaces
{
    public interface IElectricityReadingService
    {
        ServiceResult<ElectricityReading> RegisterReading(ElectricityReading electricityReading);

        ServiceResult<ElectricityReading> GetRecentReadingByPanelId(string panelId);
    }
}
