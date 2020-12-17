using SolarEnergySystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarEnergySystem.Core.Interfaces
{
    public interface IPanelRepository
    {
        IEnumerable<Panel> GetPanelsByDescendingOrder(); 
    }
}
