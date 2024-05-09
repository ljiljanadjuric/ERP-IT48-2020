using ProdavnicaObuce.Interface;
using ProdavnicaObuce.Models;
using ProdavnicaObuce.Settings;

namespace ProdavnicaObuce.UnitOfWorkConfig
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProdavnicaDbContext _context;

        public UnitOfWork(ProdavnicaDbContext context,
            IRepository<Korisinik> korisnici,
        IRepository<Dobavljac> dobavljaci,
        IRepository<Porudzbina> porudzbine,
        IRepository<Prodaja> prodaje,
        IRepository<Proizvod> proizvodi,
        IRepository<StavkaProdaje> stavkeProdaje,
        IRepository<StavkaPorudzbine> stavkePorudzbine)
        {
            _context = context;
            Korisnici = korisnici;
            Dobavljaci = dobavljaci;
            Porudzbine = porudzbine;
            Prodaje = prodaje;
            Proizvodi = proizvodi;
            StavkeProdaje = stavkeProdaje;
            StavkePorudzbine = stavkePorudzbine;
        }

        public IRepository<Korisinik> Korisnici { get; }
        public IRepository<Dobavljac> Dobavljaci { get; }
        public IRepository<Porudzbina> Porudzbine { get; }
        public IRepository<Prodaja> Prodaje { get; }
        public IRepository<Proizvod> Proizvodi { get; }
        public IRepository<StavkaProdaje> StavkeProdaje { get; }
        public IRepository<StavkaPorudzbine> StavkePorudzbine { get; }



        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
