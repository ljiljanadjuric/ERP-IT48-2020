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
            CreateMap<Proizvod, KlijentProizvodDTO>().ReverseMap();
            CreateMap<Proizvod, KreirajProizvodDTO>().ReverseMap();
            CreateMap<Dobavljac, KreirajDobavljacaDTO>().ReverseMap();
            CreateMap<StavkaPorudzbine, StavkaPorudzbineDTO>().ReverseMap();
            CreateMap<Porudzbina, PorudzbinaDTO>().ReverseMap();
            CreateMap<StavkaKupovineDTO, StavkaProdaje>().ReverseMap();
            CreateMap<Prodaja, KupiProizvodDTO>().ReverseMap();
            CreateMap<Porudzbina, PorudzbinaStanjeDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(porudzbina =>

                   (porudzbina.Status == "Naruceno" && DateTime.Now > porudzbina.VremeDostave) ?
                        "Ceka na prijem" :
                        porudzbina.Status
                ));
        }
    }
}
