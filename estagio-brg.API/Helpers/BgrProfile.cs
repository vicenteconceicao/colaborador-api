using AutoMapper;
using estagio_brg.API.Dtos;
using estagio_brg.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Helpers
{
    public class BgrProfile : Profile
    {
        public BgrProfile()
        {
            CreateMap<Colaborador, ColaboradorDto>().ReverseMap();
            CreateMap<Habilidade, HabilidadeDto>().ReverseMap();
            CreateMap<Trilha, TrilhaDto>().ReverseMap();
        }
    }
}
