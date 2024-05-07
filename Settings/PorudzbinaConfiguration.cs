using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaObuce.Models;

namespace ProdavnicaObuce.Settings
{
    public class PorudzbinaConfiguration : IEntityTypeConfiguration<Porudzbina>
    {
        public void Configure(EntityTypeBuilder<Porudzbina> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.VremePorudzbe).IsRequired();
            builder.Property(x => x.VremeDostave).IsRequired();
            builder.Property(x => x.CenaPorudzbine).IsRequired();

            builder.HasOne(x => x.Korisinik)
                .WithMany(k => k.Porudzbine)
                .HasForeignKey(k => k.IdZaposlenog);

            builder.HasOne(x => x.Dobavljac)
                .WithMany(k => k.Porudzbine)
                .HasForeignKey(k => k.IdDobavljaca);
        }
    }
}
