using ProdavnicaObuce.Models;

namespace ProdavnicaObuce.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Korisinik> Korisnici { get; }
        IRepository<Dobavljac> Dobavljaci { get; }
        IRepository<Porudzbina> Porudzbine { get; }
        IRepository<Prodaja> Prodaje { get; }
        IRepository<Proizvod> Proizvodi { get; }
        IRepository<StavkaProdaje> StavkeProdaje { get; }
        IRepository<StavkaPorudzbine> StavkePorudzbine { get; }
        Task Save();
    }
}
