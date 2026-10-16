using Ferreteria.Aplicacion.Contratos;
using Ferreteria.Dominio.Modelos;
using Ferreteria.Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Infraestructura.Repositorios;

public class RepositorioArticulos : IRepositorioArticulos
{
    private readonly ContextoFerreteria contexto;

    public RepositorioArticulos(ContextoFerreteria contextoFerreteria)
    {
        contexto = contextoFerreteria;
    }

    public async Task<List<Articulo>> ObtenerTodosAsync()
    {
        return await contexto.Articulos
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Articulo?> ObtenerPorIdAsync(int id)
    {
        return await contexto.Articulos.FindAsync(id);
    }

    public async Task<Articulo> CrearAsync(Articulo nuevoArticulo)
    {
        contexto.Articulos.Add(nuevoArticulo);
        await contexto.SaveChangesAsync();

        return nuevoArticulo;
    }

    public async Task<bool> ActualizarAsync(
        int id,
        Articulo datosActualizados)
    {
        var articuloExistente = await contexto.Articulos.FindAsync(id);

        if (articuloExistente is null)
        {
            return false;
        }

        articuloExistente.Nombre = datosActualizados.Nombre;
        articuloExistente.Precio = datosActualizados.Precio;
        articuloExistente.Stock = datosActualizados.Stock;

        await contexto.SaveChangesAsync();

        return true;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var articulo = await contexto.Articulos.FindAsync(id);

        if (articulo is null)
        {
            return false;
        }

        contexto.Articulos.Remove(articulo);
        await contexto.SaveChangesAsync();

        return true;
    }
}