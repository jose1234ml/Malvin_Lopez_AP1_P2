using Malvin_Lopez_AP1_P2.Components.Dal;
using Malvin_Lopez_AP1_P2.Components.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Malvin_Lopez_AP1_P2.Components.Service
{
    public class ProductoService(IDbContextFactory<Contexto> DbContext)
    {
        public async Task<bool> Existe(int productoId)
        {
            await using var contexto = await DbContext.CreateDbContextAsync();
            return await contexto.Producto
                .AnyAsync(p => p.ProductoId == productoId);
        }

        public async Task<bool> Insertar(Producto producto)
        {
            await using var contexto = await DbContext.CreateDbContextAsync();
            contexto.Producto.Add(producto);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Producto producto)
        {
            await using var contexto = await DbContext.CreateDbContextAsync();
            contexto.Producto.Update(producto);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Producto producto)
        {
            if (await Existe(producto.ProductoId))
                return await Modificar(producto);
            else
                return await Insertar(producto);
        }

        public async Task<Producto?> Buscar(int productoId)
        {
            await using var contexto = await DbContext.CreateDbContextAsync();
            return await contexto.Producto.FindAsync(productoId);
        }

        public async Task<bool> Eliminar(int productoId)
        {
            await using var contexto = await DbContext.CreateDbContextAsync();
            return await contexto.Producto
                .AsNoTracking()
                .Where(p => p.ProductoId == productoId)
                .ExecuteDeleteAsync() > 0;
        }
        public async Task<bool> ReducirExistencia(int productoId, decimal cantidad)
        {
            await using var contexto = await DbContext.CreateDbContextAsync();
            var producto = await contexto.Producto.FindAsync(productoId);

            if (producto == null || producto.Existencia < cantidad)
                return false;
            producto.Existencia -= cantidad;
            contexto.Producto.Update(producto);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> AumentarExistencia(int productoId, decimal cantidad)
        {
            await using var contexto = await DbContext.CreateDbContextAsync();
            var producto = await contexto.Producto.FindAsync(productoId);

            if (producto == null)
                return false;
            producto.Existencia += cantidad;
            contexto.Producto.Update(producto);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<List<Producto>> Listar(Expression<Func<Producto, bool>> criterio)
        {
            await using var contexto = await DbContext.CreateDbContextAsync();
            return await contexto.Producto
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
