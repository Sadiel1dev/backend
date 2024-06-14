using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class LugarRepositorio : ILugarRepositorio
    {

        private readonly Contexto _db;
        public LugarRepositorio(Contexto db){
            _db=db;
        }


        public async Task<IReadOnlyList<Lugar>> GetLugaresRepositorioAsync()
        {
             return await _db.Lugar
             .Include(l => l.pais)
             .Include(l => l.categoria)
             .ToListAsync();
        }

        public async Task<Lugar> GetLugarRepositorioAsync(int id)
        {
            return await _db.Lugar
            .Include(l => l.pais)
            .Include(l => l.categoria)
            .FirstOrDefaultAsync(l => l.id == id);
        }
    }
}