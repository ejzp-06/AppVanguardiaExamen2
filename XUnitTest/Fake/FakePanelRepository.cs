using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Enums;
using SolarEnergySystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace XUnitTest.Fake
{
    public class FakePanelRepository : IPanelRepository
    {
        private readonly IEnumerable<Panel> _panels;

        public FakePanelRepository()
        {
            _panels = new List<Panel>()
            {
                new Panel
                {
                    Id = "ADQWE`",
                    PanelType = PanelType.Regular
                },

                new Panel
                {
                    Id = "ADQWE1",
                    PanelType = PanelType.Limited
                },
                new Panel
                {
                    Id = "ADQWE2",   
                    PanelType = PanelType.Ultimate
                },
            };
        }

        public IEnumerable<Panel> GetPanelsByDescendingOrder()
        {
            return _panels.OrderByDescending(p => p.PanelType).ToList();
        }
    }
}
