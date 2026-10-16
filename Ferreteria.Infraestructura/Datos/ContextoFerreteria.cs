using Ferreteria.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Infraestructura.Datos;

public class ContextoFerreteria : DbContext
{
    public ContextoFerreteria(
        DbContextOptions<ContextoFerreteria> opciones)
        : base(opciones)
    {
    }

    public DbSet<Articulo> Articulos => Set<Articulo>();
}