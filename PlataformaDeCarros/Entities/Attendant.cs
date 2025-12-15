namespace PlataformaDeCarros.Entities;

public class Attendant : BaseEntity
{

    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Cep { get; set; }
    public bool IsActive { get; set; }
    
    public Attendant(string name, string cpf, string email, string phone, string cep, bool isActive)
    {
        Name = name;
        Cpf = cpf;
        Email = email;
        Phone = phone;
        Cep = cep;
        IsActive = isActive;
    }
}