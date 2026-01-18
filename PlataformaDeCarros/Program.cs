using PlataformaDeCarros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlataformaDeCarros.Interface;
using PlataformaDeCarros.MappingProfille;
using PlataformaDeCarros.Repositories;
using PlataformaDeCarros.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext (PostgreeSql)
builder.Services.AddDbContext<CarsDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer(); // Necessary for API endpoints
builder.Services.AddAutoMapper(typeof(MappingProfille)); // Import MappingProfille
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly)); // For MediatR

// Dependency Injection Repository
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IAttendantRepository, AttendantRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();

// Dependency Injection Service

// Add UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add Swagger
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Plataforma de Carros API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Free", policy => 
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Plataforma de Carros API V1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("Free");
app.UseAuthorization();
app.MapControllers();

app.Run();
