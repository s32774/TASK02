namespace APBD_TASK2.Models;
public class Projector : Equipment
{
    public int Brightness { get; set; }
    public bool IsPortable { get; set; }
    public Projector(string name, string description, int brightness, bool isPortable)
        : base(name, description)
    {
        Brightness = brightness;
        IsPortable = isPortable;
    }
    public override string GetInfo()
    {
        return $"Projector: {Name}, Brightness: {Brightness}, Portable: {IsPortable}, Status: {Status}";
    }
}