

using System.Text.Json.Serialization;

namespace Domain.Dto;

    public class EquipmentItemDto
    {
    public string Name { get; set; }
    public string Status { get; set; }
    [JsonPropertyName("power-consumption")]
    public string PowerConsumption { get; set; }
    }

