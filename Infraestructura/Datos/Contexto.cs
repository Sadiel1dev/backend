using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
     public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        // Definición de DbSet para la entidad
        public DbSet<Lugar> Lugar { get; set; }
    }
}