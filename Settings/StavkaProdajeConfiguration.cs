using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaObuce.Models;

namespace ProdavnicaObuce.Settings
{
    public class StavkaProdajeConfiguration : IEntityTypeConfiguration<StavkaProdaje>
    {
        public void Configure(EntityTypeBuilder<StavkaProdaje> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Kolicina).IsRequired();

            builder.HasOne(x => x.Prodaja)
                .WithMany(k => k.StavkeProdaje)
                .HasForeignKey(k => k.IdProdaje);
            builder.HasOne(x => x.Proizvod)
                .WithMany(k => k.StavkeProdaje)
                .HasForeignKey(k => k.IdProizvoda);
        }
    }
}
