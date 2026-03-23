using APBD_TASK2.Models;

namespace APBD_TASK2.Database;

public class AppData
{
    public List<User> Users { get; } = new();
    public List<Equipment> EquipmentItems { get; } = new();
    public List<Rental> Rentals { get; } = new();
}