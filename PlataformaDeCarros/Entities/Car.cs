namespace PlataformaDeCarros.Entities;

public class Car : BaseEntity
{

    public string Model { get; set; }
    public string Color { get; set; }
    public string Brand { get; set; }
    public string Plate { get; set; }
    public int Fabrication { get; set; } // Year of fabrication
    
    public Car() { } // For EF core
}