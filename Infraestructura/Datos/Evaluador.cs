using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificaciones;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class Evaluador<T> where T : class
    {
       public static IQueryable<T> GetQuery(IQueryable<T> input,IEspesificacion<T> espec)
       {
            var query= input;
            if (espec.filtro != null)
            {
                query=query.Where(espec.filtro);
            }

            query=espec.includes.Aggregate(query, (current,include) =>current.Include(include));

            return query;  
       }
    }
}