using AutoMapper;
using estagio_brg.API.Dtos;
using estagio_brg.API.Dtos.Trilha;
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
            CreateMap<Colaborador, ColaboradorCreateDto>().ReverseMap();

            CreateMap<Habilidade, HabilidadeDto>().ReverseMap();
            CreateMap<Habilidade, HabilidadeCreateDto>().ReverseMap();

            CreateMap<Trilha, TrilhaDto>().ReverseMap();
            CreateMap<Trilha, TrilhaCreateDto>().ReverseMap();
            CreateMap<Trilha, TrilhaReturnDto>().ReverseMap();
        }
    }
}
