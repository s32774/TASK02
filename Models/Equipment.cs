using APBD_TASK2.Enum;
namespace APBD_TASK2.Models;
public abstract class Equipment
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public EquipmentStatus Status { get; set; }
    protected Equipment(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Status = EquipmentStatus.Available;
    }
    public abstract string GetInfo();
}