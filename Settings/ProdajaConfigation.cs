using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProdavnicaObuce.Models;

namespace ProdavnicaObuce.Settings
{
    public class ProdajaConfigation : IEntityTypeConfiguration<Prodaja>
    {
        public void Configure(EntityTypeBuilder<Prodaja> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.VremeProdaje).IsRequired();
            builder.Property(x => x.CenaProdaje).IsRequired();
            builder.Property(x => x.NacinPlacanja).HasConversion(new EnumToStringConverter<NacinPlacanja>()).IsRequired();

            builder.HasOne(x => x.Kupac)
                .WithMany(k => k.Prodaje)
                .HasForeignKey(k => k.IdKupca);

            builder.HasMany(x => x.StavkeProdaje)
                .WithOne(p => p.Prodaja)
                .HasForeignKey(p => p.IdProdaje)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
