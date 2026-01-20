namespace PlataformaDeCarros.Entities;

public class Attendant : BaseEntity
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Cep { get; set; }
    public bool IsActive { get; set; } = true;
    
    public Attendant() { }
}