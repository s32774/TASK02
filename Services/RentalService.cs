using APBD_TASK2.Database;
using APBD_TASK2.Enum;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;
namespace APBD_TASK2.Services
{
    public class RentalService : IRentalService
    {
        private readonly Singleton _db = Singleton.Instance;
        public void AddUser(User user)
        {
            _db.Users.Add(user);
        }
        public void AddEquipment(Equipment equipment)
        {
            _db.EquipmentItems.Add(equipment);
        }
        public List<Equipment> GetAllEquipment()
        {
            return _db.EquipmentItems;
        }

        public List<Equipment> GetAvailableEquipment()
        {
            List<Equipment> availableEquipment = new List<Equipment>();

            foreach (var equipment in _db.EquipmentItems)
            {
                if (equipment.Status == EquipmentStatus.Available)
                {
                    availableEquipment.Add(equipment);
                }
            }

            return availableEquipment;
        }

        public void RentEquipment(Guid userId, Guid equipmentId, int days)
        {
            User user = null;
            Equipment equipment = null;

            foreach (var u in _db.Users)
            {
                if (u.Id == userId)
                {
                    user = u;
                    break;
                }
            }

            foreach (var e in _db.EquipmentItems)
            {
                if (e.Id == equipmentId)
                {
                    equipment = e;
                    break;
                }
            }

            if (user == null || equipment == null)
            {
                throw new Exception("User or equipment not found");
            }

            if (equipment.Status != EquipmentStatus.Available)
            {
                throw new Exception("Equipment is not available");
            }

            int activeRentals = 0;

            foreach (var rental in _db.Rentals)
            {
                if (rental.User.Id == userId && rental.IsActive())
                {
                    activeRentals++;
                }
            }

            if (user.UserType == UserType.Student && activeRentals >= 2)
            {
                throw new Exception("Student exceeded rental limit");
            }

            if (user.UserType == UserType.Employee && activeRentals >= 5)
            {
                throw new Exception("Employee exceeded rental limit");
            }

            Rental newRental = new Rental(user, equipment, days);
            equipment.Status = EquipmentStatus.Rented;
            _db.Rentals.Add(newRental);
        }

        public decimal ReturnEquipment(Guid rentalId)
        {
            Rental rental = null;

            foreach (var r in _db.Rentals)
            {
                if (r.Id == rentalId)
                {
                    rental = r;
                    break;
                }
            }
            if (rental == null)
            {
                throw new Exception("Rental not found");
            }

            if (!rental.IsActive())
            {
                throw new Exception("Equipment already returned");
            }

            rental.ReturnDate = DateTime.Now;
            rental.Equipment.Status = EquipmentStatus.Available;

            decimal penalty = 0;

            if (rental.ReturnDate > rental.DueDate)
            {
                int lateDays = (rental.ReturnDate.Value.Date - rental.DueDate.Date).Days;
                penalty = lateDays * 5;
            }

            rental.Penalty = penalty;
            return penalty;
        }

        public List<Rental> GetActiveRentalsForUser(Guid userId)
        {
            List<Rental> activeRentals = new List<Rental>();

            foreach (var rental in _db.Rentals)
            {
                if (rental.User.Id == userId && rental.IsActive())
                {
                    activeRentals.Add(rental);
                }
            }

            return activeRentals;
        }

        public List<Rental> GetOverdueRentals()
        {
            List<Rental> overdueRentals = new List<Rental>();

            foreach (var rental in _db.Rentals)
            {
                if (rental.IsOverdue())
                {
                    overdueRentals.Add(rental);
                }
            }

            return overdueRentals;
        }
        public string GetSummaryReport()
        {
            return "Users: " + _db.Users.Count +
                   ", Equipment: " + _db.EquipmentItems.Count +
                   ", Rentals: " + _db.Rentals.Count;
        }

        public void MarkEquipmentUnavailable(Guid equipmentId)
        {
            Equipment equipment = null;

            foreach (var e in _db.EquipmentItems)
            {
                if (e.Id == equipmentId)
                {
                    equipment = e;
                    break;
                }
            }
            if (equipment == null)
            {
                throw new Exception("Equipment not found");
            }

            if (equipment.Status == EquipmentStatus.Rented)
            {
                throw new Exception("Equipment is rented");
            }

            equipment.Status = EquipmentStatus.Unavailable;
        }
    }
}