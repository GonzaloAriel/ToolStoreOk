using Ferreteria.Aplicacion.Contratos;
using Ferreteria.Aplicacion.Servicios;
using Ferreteria.Dominio.Modelos;
using Moq;

namespace Ferreteria.Pruebas.Servicios;

public class ServicioArticulosPruebas
{
    [Fact]
    public async Task ObtenerTodosAsync_DevuelveLosArticulosDelRepositorio()
    {
        // Preparar: definimos lo que devolverá la dependencia.
        var articulosEsperados = new List<Articulo>
        {
            new Articulo
            {
                Id = 1,
                Nombre = "Martillo",
                Precio = 8500m,
                Stock = 12
            },
            new Articulo
            {
                Id = 2,
                Nombre = "Pinza",
                Precio = 6900m,
                Stock = 8
            }
        };

        var repositorioSimulado = new Mock<IRepositorioArticulos>();

        repositorioSimulado
            .Setup(repositorio => repositorio.ObtenerTodosAsync())
            .ReturnsAsync(articulosEsperados);

        var servicio = new ServicioArticulos(
            repositorioSimulado.Object);

        // Actuar: ejecutamos el método que queremos comprobar.
        var resultado = await servicio.ObtenerTodosAsync();

        // Comprobar: verificamos el resultado.
        Assert.Equal(2, resultado.Count);
        Assert.Equal("Martillo", resultado[0].Nombre);
        Assert.Equal("Pinza", resultado[1].Nombre);
    }
}