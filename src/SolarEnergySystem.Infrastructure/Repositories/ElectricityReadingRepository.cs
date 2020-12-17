using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarEnergySystem.Infrastructure.Repositories
{
    public class ElectricityReadingRepository : IElectricityReadingRepository
    {

        private readonly SolarEnergySystemDatabaseContext _context;

        public ElectricityReadingRepository(SolarEnergySystemDatabaseContext context)
        {
            _context = context;
        }

        public ElectricityReading GetRecentReadingByPanelId(string panelId)
        {
            return _context.ElectricityReading.Where(r => r.Panel.Id == panelId).OrderByDescending(r => r.ReadingDateTime).FirstOrDefault();
        }

        public ElectricityReading RegisterReding(ElectricityReading electricityReading)
        {
            var result = _context.ElectricityReading.Add(electricityReading);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
