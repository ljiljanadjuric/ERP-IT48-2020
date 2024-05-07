using ProdavnicaObuce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ProdavnicaObuce.Settings
{
    public class KorisinikConfiguration : IEntityTypeConfiguration<Korisinik>
    {
        public void Configure(EntityTypeBuilder<Korisinik> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.KorisnickoIme).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.KorisnickoIme).IsUnique();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Sifra).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Adresa).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Tip).HasConversion(new EnumToStringConverter<TipKorisnika>()).IsRequired();
        
            builder.HasMany(x => x.Porudzbine)
                .WithOne(p => p.Korisinik)
                .HasForeignKey(p => p.IdZaposlenog)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Prodaje)
                .WithOne(p => p.Kupac)
                .HasForeignKey(p => p.IdKupca)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
