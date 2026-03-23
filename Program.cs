using APBD_TASK2.Database;
using APBD_TASK2.Enum;
using APBD_TASK2.Models;
using APBD_TASK2.Services;

var db = Singleton.Instance;
var service = new RentalService();
var user1 = new User("olena", "Chornobai", UserType.Student);
var user2 = new User("Alex", "Ruban", UserType.Employee);
var user3 = new User("Maria", "Lis", UserType.Student);

service.AddUser(user1);
service.AddUser(user2);
service.AddUser(user3);
Console.WriteLine("Users:");
Console.WriteLine(user1.ShortInfo);
Console.WriteLine(user2.ShortInfo);
Console.WriteLine(user3.ShortInfo);

var laptop = new Laptop("Lenovo", "Office laptop", 16, "i7");
var camera = new Camera("Canon", "Photo camera", 24, true);
var projector = new Projector("Epson", "HD projector", 3000, true);
var laptop2 = new Laptop("Lenovo", "Student laptop", 8, "i5");

service.AddEquipment(laptop);
service.AddEquipment(camera);
service.AddEquipment(projector);
service.AddEquipment(laptop2);
Console.WriteLine("All equipment:");
foreach (var e in service.GetAllEquipment())
{
    Console.WriteLine(e.GetInfo());
}

Console.WriteLine("Renting laptop to student");
service.RentEquipment(user1.Id, laptop.Id, 3);
try
{
    Console.WriteLine("Trying to rent same laptop again");
    service.RentEquipment(user2.Id, laptop.Id, 3);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
var rental = db.Rentals[0];
Console.WriteLine("Returning equipment");
var penalty = service.ReturnEquipment(rental.Id);
Console.WriteLine("Penalty: " + penalty);
Console.WriteLine("report");
Console.WriteLine(service.GetSummaryReport());
Console.WriteLine("Available equipment:");
foreach (var e in service.GetAvailableEquipment())
{
    Console.WriteLine(e.GetInfo());
}
Console.WriteLine("Marking projector as unavailable...");
service.MarkEquipmentUnavailable(projector.Id);
Console.WriteLine("Available equipment after change:");
foreach (var e in service.GetAvailableEquipment())
{
    Console.WriteLine(e.GetInfo());
}
Console.WriteLine("Overdue rentals:");
foreach (var r in service.GetOverdueRentals())
{
    Console.WriteLine(r.Equipment.Name + " rented by " + r.User.FullName);
}
