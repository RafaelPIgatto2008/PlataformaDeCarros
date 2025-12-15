namespace PlataformaDeCarros.Entities;

public class Driver : BaseEntity
{

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Cep { get; set; }
    
    public Driver(string name, string email, string password, string phoneNumber, string cep)
    {
        Name = name;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Cep = cep;
    }
}
