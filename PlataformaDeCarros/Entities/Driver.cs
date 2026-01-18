namespace PlataformaDeCarros.Entities;

public class Driver : BaseEntity
{

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Cep { get; set; }
    
    public Driver() { } // For EF core
}
