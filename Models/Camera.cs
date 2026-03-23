namespace APBD_TASK2.Models;
public class Camera : Equipment
{
    public int Megapixels { get; set; }
    public bool HasZoom { get; set; }
    public Camera(string name, string description, int megapixels, bool hasZoom)
        : base(name, description)
    {
        Megapixels = megapixels;
        HasZoom = hasZoom;
    }
    public override string GetInfo()
    {
        return $"Camera: {Name}, MP: {Megapixels}, Zoom: {HasZoom}, Status: {Status}";
    }
}