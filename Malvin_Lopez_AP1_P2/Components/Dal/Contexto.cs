
using Microsoft.EntityFrameworkCore;
using Malvin_Lopez_AP1_P2.Components.Models;

namespace Malvin_Lopez_AP1_P2.Components.Dal;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

    public Contexto() { }

    public DbSet<Entrada> Entrada { get; set; }
    public DbSet<EntradaDetalle> EntradaDetalle { get; set; }
    public DbSet<Producto> Producto { get; set; }

    

}