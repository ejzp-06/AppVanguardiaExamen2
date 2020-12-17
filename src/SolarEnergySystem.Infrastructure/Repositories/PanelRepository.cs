using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SolarEnergySystem.Infrastructure.Repositories
{
    public class PanelRepository : IPanelRepository
    {

        private readonly SolarEnergySystemDatabaseContext _context;

        public PanelRepository(SolarEnergySystemDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Panel> GetPanelsByDescendingOrder()
        {
            return _context.Panel.OrderByDescending(p => p.PanelType).ToList();
        }
    }
}