
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Producto>().HasData(
            new Producto
            {
                ProductoId = 1,
                Descripcion = "Maní",
                Peso = 10.00m,
                Existencia = 100,
                EsCompuesto = false
            },
            new Producto
            {
                ProductoId = 2,
                Descripcion = "Pistachos",
                Peso = 5.00m,
                Existencia = 100,
                EsCompuesto = false
            },
            new Producto
            {
                ProductoId = 3,
                Descripcion = "Almendras",
                Peso = 20.00m,
                Existencia = 100,
                EsCompuesto = false
            },

             new Producto
             {
                 ProductoId = 4,
                 Descripcion = "Frutos Mixtos 200gr",
                 Peso = 200.00m,
                 Existencia = 0,
                 EsCompuesto = true
             },
            new Producto
            {
                ProductoId = 5,
                Descripcion = "Frutos Mixtos 400gr",
                Peso = 400.00m,
                Existencia = 0,
                EsCompuesto = true
            },
            new Producto
            {
                ProductoId = 6,
                Descripcion = "Frutos Mixtos 600gr",
                Peso = 600.00m,
                Existencia = 0,
                EsCompuesto = true
            }
        );
    }

}