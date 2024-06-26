using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.Extensions.Logging;

namespace Infraestructura.Datos
{
    public class Seed
    {
        public static async Task SeedAsync(Contexto context,ILoggerFactory loggerFactory){
            try
            {
                if (context.Pais.Any()==false)
                {
                    var paisData = File.ReadAllText("../Infraestructura/Datos/SeedData/paises.json");
                    var paises = JsonSerializer.Deserialize<List<Pais>>(paisData);

                    foreach (var item in paises)
                    {
                        await context.Pais.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }

                 if (context.Categoria.Any()==false)
                {
                    var categoriasData = File.ReadAllText("../Infraestructura/Datos/SeedData/categorias.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriasData);

                    foreach (var item in categorias)
                    {
                        await context.Categoria.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (context.Lugar.Any()==false)
                {
                    var lugaresData = File.ReadAllText("../Infraestructura/Datos/SeedData/lugares.json");
                    var lugares = JsonSerializer.Deserialize<List<Lugar>>(lugaresData);

                    foreach (var item in lugares)
                    {
                        await context.Lugar.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                
                var logger = loggerFactory.CreateLogger<Seed>();
                logger.LogError(ex.Message,"error al annadir datos");
            }
        }
    }
}