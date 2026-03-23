using APBD_TASK2.Enum;
namespace APBD_TASK2.Models;
public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserType UserType { get; set; }
    public User(string firstName, string lastName, UserType userType)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        UserType = userType;
    }

    public string FullName => $"{FirstName} {LastName}";
}