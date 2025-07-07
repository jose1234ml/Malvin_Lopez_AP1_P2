using Microsoft.EntityFrameworkCore;


namespace Malvin_Lopez_AP1_P2.Components.Dal
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Models.Registro> Registros { get; set; } = null!;

       
    }
}
