using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Especificaciones
{
    public class EspecificacionBase<T> : IEspesificacion<T>
    {
        public EspecificacionBase(Expression<Func<T, bool>> filtro)
        {
            this.filtro = filtro;
        }
        public EspecificacionBase()
        {
            
        }
        public Expression<Func<T, bool>> filtro { get;}

        public List<Expression<Func<T, object>>> includes { get;}=new List<Expression<Func<T, object>>>();

        public void AgregarInclude(Expression<Func<T, object>> expressions)
        {
            includes.Add(expressions);
        }
    }
}