using Microsoft.Identity.Client;
using ProdavnicaObuce.DTOs;

namespace ProdavnicaObuce.Interface
{
    public interface IKlijentServis
    {
        Task<List<KlijentProizvodDTO>> GetProizvode();
        Task KupiProizvode(KupiProizvodDTO kupiProizvodDTO, int idKupca);
        Task<List<KlijentProizvodDTO>> FiltrirajProizvode(double? cena, string? boja, string? brend);

    }
}
