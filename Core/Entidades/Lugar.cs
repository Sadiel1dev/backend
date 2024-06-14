using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Lugar
    {   [Key]
        public int id { get; set; }
        public string nombre { get; set; }

        public string descripcion { get; set; }
        public double gasto { get; set; }
        public string imagen { get; set; }

        //enlace con pais
        public int paisid { get; set; }
        [ForeignKey("paisid")]
        public Pais pais { get; set; }

        //enlace con categoria
        public int categoriaid { get; set; }
        [ForeignKey("categoriaid")]
        public Categoria categoria { get; set; }

  
    }

}