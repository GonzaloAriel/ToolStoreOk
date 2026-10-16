using Ferreteria.Dominio.Modelos;

namespace Ferreteria.Aplicacion.Contratos;

public interface IRepositorioArticulos
{
    Task<List<Articulo>> ObtenerTodosAsync();

    Task<Articulo?> ObtenerPorIdAsync(int id);

    Task<Articulo> CrearAsync(Articulo nuevoArticulo);

    Task<bool> ActualizarAsync(
        int id,
        Articulo datosActualizados);

    Task<bool> EliminarAsync(int id);
}