
namespace Domain.Equipments;

public class Equipment
{
    public const string TableName = "Equipments";
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public string PowerConsumption { get; set; }

}

