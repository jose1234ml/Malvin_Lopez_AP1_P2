using System.ComponentModel.DataAnnotations;

namespace Malvin_Lopez_AP1_P2.Components.Models
{
    public class Registro
    {
        [Key]
        public int RegistroId { get; set; }

        public string? Nombre { get; set; }
        

        
    }
}
