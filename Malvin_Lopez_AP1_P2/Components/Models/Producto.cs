public class Producto
{
    public int ProductoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;  
    public decimal PesoUnitario { get; set; }
    public int Existencia { get; set; }
    public bool EsCompuesto { get; set; }
    public int Peso { get; internal set; }
}