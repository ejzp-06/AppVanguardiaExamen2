using SolarEnergySystem.Core.Enums;
using SolarEnergySystem.Core.Interfaces;
using SolarEnergySystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitTest.Fake;

namespace XUnitTest
{
    public class PanelServiceTest
    {
        private PanelService GetPanelService()
        {
            return new PanelService(new FakePanelRepository());
        }

        [Fact]
        public void GetPanelsByDescendingOrder()
        {
            var service = GetPanelService();

            var result = service.GetPanelsByDescedingOrder();

            Assert.True(result.ResponseCode == ResponseCode.Success);
            Assert.NotNull(result);
        }
    }
}
