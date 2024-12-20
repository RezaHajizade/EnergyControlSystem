
using Domain.Equipments;
using Domain.Dto;
using System.Text.Json.Serialization;

namespace Domain.EnergyStatuses;

    public class EnergyStatus
    {
        public DateTime Timestamp { get; set; }

    [JsonPropertyName("equipment")]
    public List<EquipmentItemDto> equipments { get; set; }
    }

