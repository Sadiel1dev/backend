using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS;
using AutoMapper;
using Core.Entidades;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Lugar,LugarDTO>()
            .ForMember(d=>d.pais,o=>o.MapFrom(s=>s.pais.nombre))
            .ForMember(d=>d.categoria,o=>o.MapFrom(s=>s.categoria.nombre))
            .ForMember(d=>d.imagen,o=>o.MapFrom<LugarUrlResolver>());
        }
    }
}