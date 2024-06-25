using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS;
using AutoMapper;
using Core.Entidades;

namespace API.Helpers
{
    public class LugarUrlResolver : IValueResolver<Lugar, LugarDTO, string>
    {
        public readonly IConfiguration Config ;
        public LugarUrlResolver(IConfiguration config)
        {
            this.Config = config;
        }

        public string Resolve(Lugar source, LugarDTO destination, string destMember, ResolutionContext context)
        {
           if (!string.IsNullOrEmpty(source.imagen))
           {
             return Config["ApiUrl"]+source.imagen;
           }
           return null;
        }
    }
}