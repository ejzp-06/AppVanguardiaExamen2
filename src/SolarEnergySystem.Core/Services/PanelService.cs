using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarEnergySystem.Core.Services
{
    public class PanelService : IPanelService
    {
        private readonly IPanelRepository _panelRepository;
        public PanelService(IPanelRepository panelRepository)
        {
            _panelRepository = panelRepository;
        }


        public ServiceResult<IEnumerable<Panel>> GetPanelsByDescedingOrder()
        {
            return ServiceResult<IEnumerable<Panel>>.SuccessResult(_panelRepository.GetPanelsByDescendingOrder());
        }
    }
}
