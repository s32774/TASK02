namespace APBD_TASK2.Models;
public class Rental
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal Penalty { get; set; }
    public Rental(User user, Equipment equipment, int days)
    {
        Id = Guid.NewGuid();
        User = user;
        Equipment = equipment;
        RentalDate = DateTime.Now;
        DueDate = RentalDate.AddDays(days);
        ReturnDate = null;
        Penalty = 0;
    }
    public bool IsActive()
    {
        return ReturnDate == null;
    }

    public bool IsOverdue()
    {
        return ReturnDate == null && DateTime.Now > DueDate;
    }
}