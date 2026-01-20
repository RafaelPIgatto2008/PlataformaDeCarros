using System.ComponentModel.DataAnnotations;

namespace Plataform.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}