using Ferreteria.Aplicacion.Contratos;
using Ferreteria.Aplicacion.Servicios;
using Ferreteria.Infraestructura.Datos;
using Ferreteria.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;

var constructor = WebApplication.CreateBuilder(args);

constructor.Services.AddControllers();

constructor.Services.AddDbContext<ContextoFerreteria>(opciones =>
    opciones.UseSqlite(
        constructor.Configuration.GetConnectionString("Ferreteria")));

constructor.Services.AddScoped<IRepositorioArticulos, RepositorioArticulos>();
constructor.Services.AddScoped<ServicioArticulos>();

var aplicacion = constructor.Build();

using (var alcance = aplicacion.Services.CreateScope())
{
    var contexto = alcance.ServiceProvider
        .GetRequiredService<ContextoFerreteria>();
    contexto.Database.Migrate();
}

aplicacion.MapControllers();

aplicacion.Run();