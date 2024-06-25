using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Especificaciones
{
    public interface IEspesificacion<T>
    {
        Expression<Func<T, bool>> filtro { get;}
        List<Expression<Func<T, object>>> includes { get;}
    }
}