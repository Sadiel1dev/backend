using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Infraestructura.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
       
        public readonly ILugarRepositorio _repo ;

        public LugaresController(ILugarRepositorio repo){
            _repo = repo;
            
        }       
         
        [HttpGet]
       async public Task<ActionResult<List<Lugar>>> GetLugares(){
            var lugares= await _repo.GetLugaresRepositorioAsync();
            return  Ok(lugares);
        } 

        [HttpGet("{id}")]
        async public Task<ActionResult<Lugar>> GetLugares(int id){
            
            return  await _repo.GetLugarRepositorioAsync(id);
        } 
    }
}