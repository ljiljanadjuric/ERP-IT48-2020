using Microsoft.EntityFrameworkCore;
using ProdavnicaObuce.Models;

namespace ProdavnicaObuce.Settings
{
    public class ProdavnicaDbContext : DbContext
    {
        public DbSet<Dobavljac> Dobavljaci { get; set; }
        public DbSet<Korisinik> Korisnici { get; set; }
        public DbSet<Porudzbina> Porudzbine { get; set; }
        public DbSet<Prodaja> Prodaje { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<StavkaProdaje> StavkeProdaje { get; set; }
        public DbSet<StavkaPorudzbine> StavkePorudzbine { get; set; }

        public ProdavnicaDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdavnicaDbContext).Assembly);
        }
    }
}
