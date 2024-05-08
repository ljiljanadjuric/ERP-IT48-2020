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

        public async Task KreirajProizvod(KreirajProizvodDTO kreirajProizvodDTO)
        {
            var proizvod = _mapper.Map<Proizvod>(kreirajProizvodDTO);
            await _unitOfWork.Proizvodi.Insert(proizvod);
            await _unitOfWork.Save();
        }
    }
}
