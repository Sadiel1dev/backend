using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificaciones;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly Contexto db;

        public Repositorio(Contexto db)
        {
            this.db = db;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await db.Set<T>().FindAsync();
        }

        public async Task<T> ObtenerEspec(IEspesificacion<T> espec)
        {
            return await Aplicar(espec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ObtenerTodoEspec(IEspesificacion<T> espec)
        {
            return await Aplicar(espec).ToListAsync();
        }

        private IQueryable<T> Aplicar(IEspesificacion<T> espec)
        {
            return Evaluador<T>.GetQuery(db.Set<T>().AsQueryable(),espec);
        }

    }
}