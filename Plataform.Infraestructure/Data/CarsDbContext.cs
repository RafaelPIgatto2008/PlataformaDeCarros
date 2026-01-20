using Microsoft.EntityFrameworkCore;
using PlataformaDeCarros.Entities;

namespace Plataform.Infraestructure.Data;

public class CarsDbContext : DbContext
{
    public CarsDbContext(DbContextOptions<CarsDbContext> options)
        : base(options) { }
    
    //Entities on the DB
    public DbSet<Car> Cars { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Attendant> Attendants { get; set; }
}