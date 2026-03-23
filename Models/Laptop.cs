namespace APBD_TASK2.Models;
public class Laptop : Equipment
{
    public int RamGb { get; set; }
    public string Processor { get; set; }

    public Laptop(string name, string description, int ramGb, string processor)
        : base(name, description)
    {
        RamGb = ramGb;
        Processor = processor;
    }
    public override string GetInfo()
    {
        return $"Laptop: {Name}, RAM: {RamGb}GB, CPU: {Processor}, Status: {Status}";
    }
}