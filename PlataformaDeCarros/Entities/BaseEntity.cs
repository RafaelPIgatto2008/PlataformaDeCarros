namespace PlataformaDeCarros.Entities;

public class BaseEntity<TGuid>
{
    public TGuid Id { get; set; }
    public DateTime CreatedAt { get; set; }
}