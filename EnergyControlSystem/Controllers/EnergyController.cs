using Application.Energy.GetDeviceControl;
using Domain.Dto;
using Domain.EnergyStatuses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Polly.Timeout;
using Polly;

namespace EnergyControlSystemApi.Controllers
{
    [Route("api/v1/energy")]
    [ApiController]
    [EnableRateLimiting("limiter")]
    public class EnergyController : ControllerBase
    {
        private IGetEquipmentControlService _getDeviceControlService;
        private readonly IHttpClientFactory _clientFactory;

      
        public EnergyController(IGetEquipmentControlService getDeviceControlService
            , IHttpClientFactory clientFactory)
        {
            _getDeviceControlService = getDeviceControlService;
            _clientFactory = clientFactory;
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetEnergyStatus()
        {
            var timeoutPolicy = Policy.TimeoutAsync(3, TimeoutStrategy.Pessimistic);

            try
            {
                var result = await timeoutPolicy.ExecuteAsync(async () =>
                {

                  //  await Task.Delay(4000);  //for test my code


                    var data = _getDeviceControlService.GetAllDevices();

                    var equipment = data.Select(p => new EquipmentItemDto
                    {
                        Name = p.Name,
                        PowerConsumption = p.PowerConsumption,
                        Status = p.Status,
                    }).ToList();

                    return new EnergyStatus
                    {
                        equipments = equipment,
                        Timestamp = DateTime.UtcNow,
                    };
                });

                return Ok(result);
            }
            catch (TimeoutRejectedException)
            {
                return StatusCode(StatusCodes.Status504GatewayTimeout, "Request timed out");
            }
       

        }
    
    }
}
