using Ferreteria.Aplicacion.Servicios;
using Ferreteria.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers;

[ApiController]
[Route("api/articulos")]
public class ArticulosController : ControllerBase
{
    private readonly ServicioArticulos servicio;

    public ArticulosController(ServicioArticulos servicioArticulos)
    {
        servicio = servicioArticulos;
    }

    [HttpGet]
    public async Task<ActionResult<List<Articulo>>> ObtenerArticulos()
    {
        var articulos = await servicio.ObtenerTodosAsync();
        return Ok(articulos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Articulo>> ObtenerArticuloPorId(int id)
    {
        var articulo = await servicio.ObtenerPorIdAsync(id);

        if (articulo is null)
        {
            return NotFound();
        }

        return Ok(articulo);
    }

    [HttpPost]
    public async Task<ActionResult<Articulo>> CrearArticulo(
        Articulo nuevoArticulo)
    {
        var articuloCreado = await servicio.CrearAsync(nuevoArticulo);

        return CreatedAtAction(
            nameof(ObtenerArticuloPorId),
            new { id = articuloCreado.Id },
            articuloCreado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarArticulo(
        int id,
        Articulo datosActualizados)
    {
        bool actualizado =
            await servicio.ActualizarAsync(id, datosActualizados);

        if (!actualizado)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarArticulo(int id)
    {
        bool eliminado = await servicio.EliminarAsync(id);

        if (!eliminado)
        {
            return NotFound();
        }

        return NoContent();
    }
}