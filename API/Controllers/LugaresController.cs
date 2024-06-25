using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS;
using AutoMapper;
using Core.Entidades;
using Core.Especificaciones;
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
       
        public readonly IRepositorio<Lugar> lugar ;
        public readonly IRepositorio<Pais> pais ;
        public readonly IRepositorio<Categoria> categoria ;
        private readonly IMapper mapper;

        public LugaresController(IRepositorio<Lugar> lugar, IRepositorio<Pais> pais, IRepositorio<Categoria> categoria,IMapper mapper)
        {
            this.mapper = mapper;
            this.categoria = categoria;
            this.pais = pais;
            this.lugar = lugar;
            
        }       
         
        [HttpGet]
       async public Task<ActionResult<IReadOnlyList<LugarDTO>>> GetLugares(){
            var espec=new LugaresPaisCategoria();
            var lugares= await lugar.ObtenerTodoEspec(espec);
            return  Ok(mapper.Map<IReadOnlyList<Lugar>,IReadOnlyList<LugarDTO>>(lugares));
        } 

        [HttpGet("{id}")]
        async public Task<ActionResult<LugarDTO>> GetLugar(int id){
            var espec=new LugaresPaisCategoria(id);
            var result =  await lugar.ObtenerEspec(espec);
            return mapper.Map<Lugar,LugarDTO>(result);
        } 



        [HttpGet("paises")]
       async public Task<ActionResult<List<Pais>>> GetPaises(){
            var paises= await pais.GetAllAsync();
            return  Ok(paises);
        } 


        [HttpGet("categorias")]
       async public Task<ActionResult<List<Categoria>>> GetCategoria(){
            var categorias= await categoria.GetAllAsync();
            return  Ok(categorias);
        } 
    }
}