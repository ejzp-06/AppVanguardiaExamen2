using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarEnergySystem.Core.Services
{
    public class ElectricityReadingService : IElectricityReadingService
    {
        private readonly IElectricityReadingRepository _electricityReadingRepository;
        public ElectricityReadingService(IElectricityReadingRepository electricityReadingRepository)
        {
            _electricityReadingRepository = electricityReadingRepository;
        }

        public ServiceResult<ElectricityReading> GetRecentReadingByPanelId(string panelId)
        {
            return ServiceResult<ElectricityReading>.SuccessResult(_electricityReadingRepository.GetRecentReadingByPanelId(panelId));
        }

        public ServiceResult<ElectricityReading> RegisterReading(ElectricityReading electricityReading)
        {
            return ServiceResult<ElectricityReading>.SuccessResult(_electricityReadingRepository.RegisterReding(electricityReading));
        }
    }
}
