namespace PlataformaDeCarros.Entities;

public class Car : BaseEntity
{

    public string Model { get; set; }
    public string Color { get; set; }
    public string Brand { get; set; }
    public string Plate { get; set; }
    public int Fabrication { get; set; } // Year of fabrication
    
    public Car(string model, string color, string brand, string plate, int fabrication)
    {
        Model = model;
        Color = color;
        Brand = brand;
        Plate = plate;
        Fabrication = fabrication;
    }
}