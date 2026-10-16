using Ferreteria.Aplicacion.Contratos;
using Ferreteria.Dominio.Modelos;

namespace Ferreteria.Aplicacion.Servicios;

public class ServicioArticulos
{
    private readonly IRepositorioArticulos repositorio;

    public ServicioArticulos(IRepositorioArticulos repositorioArticulos)
    {
        repositorio = repositorioArticulos;
    }

    public Task<List<Articulo>> ObtenerTodosAsync()
    {
        return repositorio.ObtenerTodosAsync();
    }

    public Task<Articulo?> ObtenerPorIdAsync(int id)
    {
        return repositorio.ObtenerPorIdAsync(id);
    }

    public Task<Articulo> CrearAsync(Articulo nuevoArticulo)
    {
        return repositorio.CrearAsync(nuevoArticulo);
    }

    public Task<bool> ActualizarAsync(
        int id,
        Articulo datosActualizados)
    {
        return repositorio.ActualizarAsync(id, datosActualizados);
    }

    public Task<bool> EliminarAsync(int id)
    {
        return repositorio.EliminarAsync(id);
    }
}