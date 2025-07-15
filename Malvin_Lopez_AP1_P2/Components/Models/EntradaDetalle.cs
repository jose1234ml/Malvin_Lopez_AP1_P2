using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Malvin_Lopez_AP1_P2.Components.Models;

public class EntradaDetalle
{
    [Key]
    public int EntradaDetalleId { get; set; }

    public int EntradaId { get; set; }

    public int ProductoId { get; set; }

    public string NombreProducto { get; set; } = string.Empty;

    public decimal PesoTotal { get; set; }

    public int Cantidad { get; set; }

    [ForeignKey("EntradaId")]
    public Entrada? Entrada { get; set; }
}