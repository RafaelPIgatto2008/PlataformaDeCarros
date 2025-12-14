namespace PlataformaDeCarros.Entities;

public class Car : BaseEntity<Guid>
{

    public string Model { get; set; }
    public string Color { get; set; }
    public string Brand { get; set; }
    public string Plate { get; set; }
    public DateTime Fabrication { get; set; } // Year of fabrication
    
    public Car(string model, string color, string brand, string plate, DateTime fabrication)
    {
        Model = model;
        Color = color;
        Brand = brand;
        Plate = plate;
        Fabrication = fabrication;
    }
}