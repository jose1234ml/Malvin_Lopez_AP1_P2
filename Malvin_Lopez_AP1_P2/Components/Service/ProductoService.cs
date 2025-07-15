using Microsoft.EntityFrameworkCore;
using Malvin_Lopez_AP1_P2.Components.Models;
using System.Linq.Expressions;
using Malvin_Lopez_AP1_P2.Components.Dal;

namespace Malvin_Lopez_AP1_P2.Components.Services;

public class ProductoService
{
    private readonly Contexto _contexto;

    public ProductoService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Producto>> Listar(Expression<Func<Producto, bool>> filtro)
    {
        return await _contexto.Productos.Where(filtro).AsNoTracking().ToListAsync();
    }
}