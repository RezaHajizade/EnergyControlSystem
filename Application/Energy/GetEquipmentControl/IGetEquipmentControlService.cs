using Application.Interface.Context;
using Domain.Dto;
using Domain.EnergyStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Energy.GetDeviceControl
{
    public interface IGetEquipmentControlService
    {
        List<EquipmentControlDto> GetAllDevices();
    }
  
}
