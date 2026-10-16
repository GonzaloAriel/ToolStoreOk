using System.Net.Http.Json;
using Ferreteria.Blazor.Modelos;

namespace Ferreteria.Blazor.Servicios;

public class ServicioArticulosWeb
{
    private readonly HttpClient cliente;

    public ServicioArticulosWeb(HttpClient clienteHttp)
    {
        cliente = clienteHttp;
    }

    public async Task<List<ArticuloWeb>> ObtenerTodosAsync()
    {
        return await cliente.GetFromJsonAsync<List<ArticuloWeb>>(
            "api/articulos") ?? new List<ArticuloWeb>();
    }

    public async Task<ArticuloWeb?> ObtenerPorIdAsync(int id)
    {
        return await cliente.GetFromJsonAsync<ArticuloWeb>(
            $"api/articulos/{id}");
    }

    public async Task<ArticuloWeb> CrearAsync(
        ArticuloWeb nuevoArticulo)
    {
        var respuesta = await cliente.PostAsJsonAsync(
            "api/articulos",
            nuevoArticulo);

        respuesta.EnsureSuccessStatusCode();

        return await respuesta.Content.ReadFromJsonAsync<ArticuloWeb>()
            ?? throw new InvalidOperationException(
                "La API no devolvió el artículo creado.");
    }

    public async Task ActualizarAsync(
        int id,
        ArticuloWeb articulo)
    {
        var respuesta = await cliente.PutAsJsonAsync(
            $"api/articulos/{id}",
            articulo);

        respuesta.EnsureSuccessStatusCode();
    }

    public async Task EliminarAsync(int id)
    {
        var respuesta = await cliente.DeleteAsync(
            $"api/articulos/{id}");

        respuesta.EnsureSuccessStatusCode();
    }
}