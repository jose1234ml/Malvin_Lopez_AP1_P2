
using System.ComponentModel.DataAnnotations;

namespace Malvin_Lopez_AP1_P2.Components.Models;

public class Entrada
{
    [Key]
    public int EntradaId { get; set; }

    [Required(ErrorMessage = "El campo concepto es obligatorio.")]
    public string Concepto { get; set; } = string.Empty;
    public decimal PesoTotal { get; set; }

    [Required]
    public DateTime Fecha { get; set; } = DateTime.Today;


    public List<EntradaDetalle> EntradaDetalle { get; set; } = new();
}