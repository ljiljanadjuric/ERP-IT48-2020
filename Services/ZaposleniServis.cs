using AutoMapper;
using ProdavnicaObuce.DTOs;
using ProdavnicaObuce.Interface;
using ProdavnicaObuce.Models;

namespace ProdavnicaObuce.Services
{
    public class ZaposleniServis : IZaposleniServis
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ZaposleniServis(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProizvodDTO>> GetProizvode()
        {
            var proizvodi = await _unitOfWork.Proizvodi.GetAll();
            return _mapper.Map<List<ProizvodDTO>>(proizvodi);
        }

        public async Task KreirajDobavljaca(KreirajDobavljacaDTO kreirajDobavljacaDTO)
        {
            var dobavljac = _mapper.Map<Dobavljac>(kreirajDobavljacaDTO);
            await _unitOfWork.Dobavljaci.Insert(dobavljac);
            await _unitOfWork.Save(); ;
        }

        public async Task KreirajProizvod(KreirajProizvodDTO kreirajProizvodDTO)
        {
            var proizvod = _mapper.Map<Proizvod>(kreirajProizvodDTO);
            await _unitOfWork.Proizvodi.Insert(proizvod);
            await _unitOfWork.Save();
        }

        public async Task PoruciProizvode(PorudzbinaDTO poruciProizvodDTO, int idZaposlenog)
        {
            Porudzbina porudzbina = _mapper.Map<Porudzbina>(poruciProizvodDTO);
            var dobavljac = await _unitOfWork.Dobavljaci.GetById(porudzbina.IdDobavljaca);
            if (dobavljac == null)
            {
                throw new Exception("Dobavljac ne postoji!");
            }
            List<Proizvod> proizvodi = new List<Proizvod>();
            foreach(var stavkaPorudzbine in poruciProizvodDTO.StavkePorudzbine)
            {
                Proizvod proizvod = await _unitOfWork.Proizvodi.GetById(stavkaPorudzbine.IdProizvoda);
                if (proizvod == null)
                {
                    throw new Exception("Proizvod ne postoji!");
                }
                proizvod.Kolicina += stavkaPorudzbine.Kolicina;
                proizvodi.Add(proizvod);
            }
            await _unitOfWork.Proizvodi.Save();
            porudzbina.StavkePorudzbine.ForEach(s => s.IdPorudzbine = porudzbina.Id);
            porudzbina.VremePorudzbe = DateTime.Now;
            porudzbina.VremeDostave = DateTime.Now.AddHours(3);
            porudzbina.Status = "Naruceno";
            porudzbina.CenaPorudzbine = proizvodi
                .Sum(p => p.Cena * poruciProizvodDTO.StavkePorudzbine.FirstOrDefault(s => s.IdProizvoda == p.Id).Kolicina);
            porudzbina.IdZaposlenog = idZaposlenog;
            await _unitOfWork.Porudzbine.Insert(porudzbina);
            await _unitOfWork.Save();
        }
    }
}
