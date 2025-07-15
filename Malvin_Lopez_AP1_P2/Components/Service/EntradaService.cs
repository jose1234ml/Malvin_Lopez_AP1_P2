
using Microsoft.EntityFrameworkCore;
using Malvin_Lopez_AP1_P2.Components.Dal;
using Malvin_Lopez_AP1_P2.Components.Models;
using System.Linq.Expressions;

namespace Malvin_Lopez_AP1_P2.Components.Services;

public class EntradaService
{
    private readonly Contexto _contexto;

    public EntradaService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Entrada>> Listar(Expression<Func<Entrada, bool>> criterio)
    {
        return await _contexto.Entradas
            .Include(e => e.EntradaDetalle)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Entrada?> Buscar(int id)
    {
        return await _contexto.Entradas
            .Include(e => e.EntradaDetalle)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EntradaId == id);
    }

    public async Task<bool> Guardar(Entrada entrada)
    {
        if (entrada.EntradaId == 0)
            return await Insertar(entrada);
        else
            return await Modificar(entrada);
    }

    private async Task<bool> Insertar(Entrada entrada)
    {
        _contexto.Entradas.Add(entrada);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Entrada entrada)
    {
        var existente = await _contexto.Entradas
            .Include(e => e.EntradaDetalle)
            .FirstOrDefaultAsync(e => e.EntradaId == entrada.EntradaId);

        if (existente == null)
            return false;

     
        _contexto.Entry(existente).CurrentValues.SetValues(entrada);


        _contexto.EntradaDetalles.RemoveRange(existente.EntradaDetalle);


        existente.EntradaDetalle = entrada.EntradaDetalle;

        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var entrada = await _contexto.Entradas.FindAsync(id);
        if (entrada == null) return false;

        _contexto.Entradas.Remove(entrada);
        return await _contexto.SaveChangesAsync() > 0;
    }
}