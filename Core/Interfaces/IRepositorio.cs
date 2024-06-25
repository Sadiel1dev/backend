using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificaciones;

namespace Core.Interfaces
{
    public interface IRepositorio<T> where T:class
    {
         Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        
        Task<T> ObtenerEspec(IEspesificacion<T> espec);

        Task<IReadOnlyList<T>> ObtenerTodoEspec(IEspesificacion<T> espec);
    }
}