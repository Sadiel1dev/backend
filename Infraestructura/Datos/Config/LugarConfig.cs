using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Datos.Config
{
    public class LugarConfig : IEntityTypeConfiguration<Lugar>
    {
        public void Configure(EntityTypeBuilder<Lugar> builder)
        {
            builder.Property(x => x.id).IsRequired();
            builder.Property(x => x.nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.descripcion).IsRequired();
            builder.Property(x => x.gasto).IsRequired();

            //relaciones
            builder.HasOne(c=> c.categoria).WithMany()
                    .HasForeignKey(c => c.categoriaid); 

            builder.HasOne(c=> c.pais).WithMany()
                    .HasForeignKey(c => c.paisid); 
        }
    }
}