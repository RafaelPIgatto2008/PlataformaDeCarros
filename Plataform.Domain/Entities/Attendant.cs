namespace Plataform.Domain.Entities;

public class Attendant : BaseEntity
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Cep { get; set; }
    public bool IsActive { get; set; } = true;
    
    public Attendant() { }
    
    public void Deactivate() 
    {
        IsActive = false;
    }

    public void UpdateContact(string email, string phone)
    {
        // Validações básicas antes de atribuir
        if (string.IsNullOrWhiteSpace(email)) throw new Exception("Email inválido");
        Email = email;
        Phone = phone;
    }
}