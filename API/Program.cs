

using API.Helpers;
using Core.Interfaces;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var conexion = builder.Configuration.GetConnectionString("conexion");
builder.Services.AddDbContext<Contexto>(options => options.UseMySql(conexion,ServerVersion.AutoDetect(conexion)));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
//annadir servicio para utilizar interfaz
builder.Services.AddScoped<ILugarRepositorio,LugarRepositorio>();
builder.Services.AddScoped(typeof(IRepositorio<>),typeof(Repositorio<>));
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

//migraciones automaticas
using(var scope=app.Services.CreateScope())
{
   var services =scope.ServiceProvider;
   var loggerFactory = services.GetRequiredService<ILoggerFactory>();

   try
   {
    var context =services.GetRequiredService<Contexto>();
    await context.Database.MigrateAsync();
//alimentar base de datos

    await Seed.SeedAsync(context,loggerFactory);

   }
   catch (System.Exception ex)
   {
    
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex,"Migracion fallida");
   }
}
// Configure the HTTP request pipeline. 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
