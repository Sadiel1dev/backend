using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Infraestructura.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        private readonly Contexto _db;

        public LugaresController(Contexto db){
            _db=db;
        }




        
        [HttpGet]
       async public Task<ActionResult<List<Lugar>>> GetLugares(){
            var lugares= await _db.Lugar.ToListAsync();
            return  Ok(lugares);
        } 

        [HttpGet("{id}")]
        async public Task<ActionResult<Lugar>> GetLugares(int id){
            
            return  await _db.Lugar.FindAsync(id);
        } 
    }
}