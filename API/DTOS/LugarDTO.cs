using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS
{
    public class LugarDTO
    {
      
        public int id { get; set; }
        public string nombre { get; set; }

        public string descripcion { get; set; }
        public double gasto { get; set; }
        public string imagen { get; set; }

        //enlace con pais
      
        public string pais { get; set; }

        //enlace con categoria
      
        public string categoria { get; set; }
    }
}