using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace XUnitTest.Fake
{
    public class FakeElectricityReadingRepository : IElectricityReadingRepository
    {
        private readonly IEnumerable<ElectricityReading> _electricityReadings;

        public FakeElectricityReadingRepository()
        {
            _electricityReadings = new List<ElectricityReading>
            {
                new ElectricityReading
                {
                    Id = 1,
                    ReadingDateTime = DateTime.UtcNow,
                    Panel = new Panel
                    {
                        Id = "LOPPP"
                    }
                },

                 new ElectricityReading
                {
                    Id = 1,
                    ReadingDateTime = DateTime.UtcNow.AddDays(1),
                    Panel = new Panel
                    {
                        Id = "LOPPP"
                    }
                },
            };
        }


        public ElectricityReading GetRecentReadingByPanelId(string panelId)
        {
            return _electricityReadings.Where(r => r.Panel.Id == panelId).OrderByDescending(r => r.ReadingDateTime).FirstOrDefault();
        }

        public ElectricityReading RegisterReding(ElectricityReading electricityReading)
        {
            throw new NotImplementedException();
        }
    }
}
