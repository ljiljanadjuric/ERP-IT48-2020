using ProdavnicaObuce.DTOs;
using ProdavnicaObuce.Models;

namespace ProdavnicaObuce.Interface
{
    public interface IZaposleniServis
    {
        Task<List<ProizvodDTO>> GetProizvode();
        Task KreirajProizvod(KreirajProizvodDTO kreirajProizvodDTO);
        Task KreirajDobavljaca(KreirajDobavljacaDTO kreirajDobavljacaDTO);
        Task PoruciProizvode(PorudzbinaDTO poruciProizvodDTO, int idZaposlenog);
        public Task<List<PorudzbinaStanjeDTO>> PregledajSvePorudzbine();
        public Task<List<PorudzbinaStanjeDTO>> PregledajPorudzbineKojeCekajuDaSePreuzmu();
        public Task PreuzmiPorudzbinu(int idPorudzbine);
        Task<List<ProdajaDto>> PregledajSveProdaje();
    }
}
