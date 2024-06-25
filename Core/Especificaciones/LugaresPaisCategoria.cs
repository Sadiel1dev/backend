using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Especificaciones
{
    public class LugaresPaisCategoria:EspecificacionBase<Lugar>
    {
        public LugaresPaisCategoria()
        {
            AgregarInclude(x=>x.pais);
            AgregarInclude(x=>x.categoria);
        }

        public LugaresPaisCategoria(int id) : base(x=>x.id==id)
        {
            AgregarInclude(x=>x.pais);
            AgregarInclude(x=>x.categoria);
        }
    }
}