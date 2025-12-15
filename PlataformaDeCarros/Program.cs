using PlataformaDeCarros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext (PostgreeSql)
builder.Services.AddDbContext<CarsDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer(); // Necessary for API endpoints
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Plataforma de Carros API", Version = "v1" });
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
app.MapControllers();


app.Run();
