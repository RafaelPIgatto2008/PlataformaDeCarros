using Microsoft.EntityFrameworkCore;

namespace PlataformaDeCarros.CarsDbContext;

public class CarsDbContext : DbContext
{
    public CarsDbContext(DbContextOptions<CarsDbContext> options)
        : base(options) { }
    
}