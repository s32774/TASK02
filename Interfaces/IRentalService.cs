using APBD_TASK2.Models;
namespace APBD_TASK2.Interfaces
{
    public interface IRentalService
    {
        void AddUser(User user);
        void AddEquipment(Equipment equipment);
        List<Equipment> GetAllEquipment();
        List<Equipment> GetAvailableEquipment();
        void RentEquipment(Guid userId, Guid equipmentId, int days);
        decimal ReturnEquipment(Guid rentalId);
        void MarkEquipmentUnavailable(Guid equipmentId);
        List<Rental> GetActiveRentalsForUser(Guid userId);
        List<Rental> GetOverdueRentals();
        string GetSummaryReport();
    }
}