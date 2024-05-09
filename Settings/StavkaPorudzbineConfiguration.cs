using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaObuce.Models;

namespace ProdavnicaObuce.Settings
{
    public class StavkaPorudzbineConfiguration : IEntityTypeConfiguration<StavkaPorudzbine>
    {
        public void Configure(EntityTypeBuilder<StavkaPorudzbine> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Kolicina).IsRequired();


            builder.HasOne(x => x.Porudzbina)
                .WithMany(p => p.StavkePorudzbine)
                .HasForeignKey(x => x.IdPorudzbine);

            builder.HasOne(x => x.Proizvod)
                .WithMany(p => p.StavkePorudzbine)
                .HasForeignKey(x => x.IdProizvoda);
        }
    }
}
