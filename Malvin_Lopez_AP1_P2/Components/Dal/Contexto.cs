// Dal/Contexto.cs
using Microsoft.EntityFrameworkCore;
using Malvin_Lopez_AP1_P2.Components.Models;

namespace Malvin_Lopez_AP1_P2.Components.Dal
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<EntradaDetalle> EntradaDetalles { get; set; }
        public DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    ProductoId = 1,
                    Descripcion = "Maní",
                    Peso = 0,
                    Existencia = 100,
                    EsCompuesto = false
                },
                new Producto
                {
                    ProductoId = 2,
                    Descripcion = "Pistachos",
                    Peso = 0,
                    Existencia = 100,
                    EsCompuesto = false
                },
                new Producto
                {
                    ProductoId = 3,
                    Descripcion = "Almendras",
                    Peso = 0,
                    Existencia = 100,
                    EsCompuesto = false
                },
                new Producto
                {
                    ProductoId = 4,
                    Descripcion = "Frutos Mixtos 200gr",
                    Peso = (int)200.00m,
                    Existencia = 0,
                    EsCompuesto = true
                },
                new Producto
                {
                    ProductoId = 5,
                    Descripcion = "Frutos Mixtos 400gr",
                    Peso = (int)400.00m,
                    Existencia = 0,
                    EsCompuesto = true
                },
                new Producto
                {
                    ProductoId = 6,
                    Descripcion = "Frutos Mixtos 600gr",
                    Peso = (int)600.00m,
                    Existencia = 0,
                    EsCompuesto = true
                }
            );
        }
    }
}