using Microsoft.Identity.Client;
using ProdavnicaObuce.DTOs;

namespace ProdavnicaObuce.Interface
{
    public interface IKlijentServis
    {
        Task<List<KlijentProizvodDTO>> GetProizvode();
        Task KupiProizvodeKes(KupiProizvodDTO kupiProizvodDTO, int idKupca);
        Task<string?> KupiProizvodeKartica(KupiProizvodDTO kupiProizvodDTO, int idKupca);
        Task<List<KlijentProizvodDTO>> FiltrirajProizvode(double? cena, string? boja, string? brend);

    }
}
