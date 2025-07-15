using System.ComponentModel.DataAnnotations;

namespace Malvin_Lopez_AP1_P2.Components.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(255, ErrorMessage = "La descripción no puede exceder los 255 caracteres.")]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "El peso es obligatorio.")]
        [Range(0.01, 999999.99, ErrorMessage = "El peso debe ser mayor a 0")]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "La existencia es obligatoria.")]
        [Range(0, int.MaxValue, ErrorMessage = "La existencia no puede ser negativa.")]
        public decimal Existencia { get; set; }

        [Required(ErrorMessage = "Debe indicar si es compuesto o no.")]
        public bool EsCompuesto { get; set; }

        public virtual ICollection<EntradaDetalle> EntradasDetalles { get; set; } = new List<EntradaDetalle>();
    }
}
