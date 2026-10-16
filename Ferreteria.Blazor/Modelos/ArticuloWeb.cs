namespace Ferreteria.Blazor.Modelos;

public class ArticuloWeb
{
    public int Id { get; set; }

    public string Nombre { get; set; } = "";

    public decimal Precio { get; set; }

    public int Stock { get; set; }
}