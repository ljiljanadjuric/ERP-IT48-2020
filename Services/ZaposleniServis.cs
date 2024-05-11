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
                proizvodi.Add(proizvod);
            }
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

        public async Task<List<PorudzbinaStanjeDTO>> PregledajPorudzbineKojeCekajuDaSePreuzmu()
        {
            var poruzbine = await _unitOfWork.Porudzbine.GetAll();
            return _mapper.Map<List<PorudzbinaStanjeDTO>>(poruzbine.Where(p => p.Status == "Naruceno" && DateTime.Now > p.VremeDostave));
        }

        public async Task<List<PorudzbinaStanjeDTO>> PregledajSvePorudzbine()
        {
            var poruzbine = await _unitOfWork.Porudzbine.GetAll();
            return _mapper.Map<List<PorudzbinaStanjeDTO>>(poruzbine);
        }

        public async Task PreuzmiPorudzbinu(int idPorudzbine)
        {
            var porudzbina = await _unitOfWork.Porudzbine.GetById(idPorudzbine);
            if(porudzbina == null)
            {
                throw new Exception("Porudzbina ne postoji!");
            }
            if(porudzbina.Status == "Preuzeta")
            {
                throw new Exception("Porudzbina je vec prezueta!");
            }
            if(DateTime.Now < porudzbina.VremeDostave)
            {
                throw new Exception("Porudzbina jos nije spremna za preuzimanje!");
            }
            foreach (var stavkaPorudzbine in porudzbina.StavkePorudzbine)
            {
                Proizvod proizvod = await _unitOfWork.Proizvodi.GetById(stavkaPorudzbine.IdProizvoda);
                if (proizvod == null)
                {
                    throw new Exception("Proizvod ne postoji!");
                }
                proizvod.Kolicina += stavkaPorudzbine.Kolicina;
            }
            porudzbina.Status = "Preuzeta";
            await _unitOfWork.Proizvodi.Save();
            await _unitOfWork.Save();
        }

    }
}
