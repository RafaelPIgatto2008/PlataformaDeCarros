namespace PlataformaDeCarros.Entities;

public class Attendant : BaseEntity
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Cep { get; set; }
    public bool IsActive { get; set; } = true;
    
    public Attendant(string name, string cpf, string email, string phone, string cep)
    {
        Name = name;
        Cpf = cpf;
        Email = email;
        Phone = phone;
        Cep = cep;
    }
}