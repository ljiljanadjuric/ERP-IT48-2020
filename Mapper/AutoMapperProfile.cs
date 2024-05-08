using AutoMapper;
using ProdavnicaObuce.DTOs;
using ProdavnicaObuce.Models;
using BC = BCrypt.Net;

namespace ProdavnicaObuce.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDTO, Korisinik>()
                    .ForMember(dest => dest.Sifra, opt => opt.MapFrom(dto => BC.BCrypt.HashPassword(dto.Sifra)));
            CreateMap<Korisinik, RegisterDTO>();
            CreateMap<Proizvod, ProizvodDTO>().ReverseMap();
            CreateMap<Proizvod, KreirajProizvodDTO>().ReverseMap();
        }
    }
}
