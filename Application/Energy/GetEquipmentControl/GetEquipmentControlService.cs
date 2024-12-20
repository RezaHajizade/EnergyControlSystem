using Application.Interface.Context;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Energy.GetDeviceControl
{
    public class GetEquipmentControlService : IGetEquipmentControlService
    {
        private readonly IDataBaseContext _context;
        public GetEquipmentControlService(IDataBaseContext context)
        {
            _context = context;
        }
        public List<EquipmentControlDto> GetAllDevices()
        {
            var data = _context.Equipments.Select(p => new EquipmentControlDto
            {
                Name = p.Name,
                Status = p.Status,
                PowerConsumption = p.PowerConsumption,
            }).ToList();

            return data;
        }
    }

}
