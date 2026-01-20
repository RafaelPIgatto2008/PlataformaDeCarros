namespace Plataform.Domain.Entities;

public class Car : BaseEntity
{

    public string Model { get; set; }
    public string Color { get; set; }
    public string Brand { get; set; }
    public string Plate { get; set; }
    public int Fabrication { get; set; } // Year of fabrication
    public CarStatus Status { get; set; }
    
    public Car() { } // For EF core
    public Car(string model, string plate, int fabrication)
    {
        // Validation year of fabrication
        if (fabrication < 1900 || fabrication > DateTime.Now.Year + 1)
            throw new Exception("Ano de fabricação inválido");

        Model = model;
        Plate = plate;
        Fabrication = fabrication;
        Status = CarStatus.Available;
    }

    public void SendToMaintenance()
    {
        if (Status == CarStatus.Rented)
            throw new Exception("Não é possível enviar para manutenção um carro alugado.");
            
        Status = CarStatus.Maintenance;
    }
}


public enum CarStatus { Available, Rented, Maintenance, OutOfService }