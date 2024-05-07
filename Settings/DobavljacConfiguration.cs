using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaObuce.Models;

namespace ProdavnicaObuce.Settings
{
    public class DobavljacConfiguration : IEntityTypeConfiguration<Dobavljac>
    {
        public void Configure(EntityTypeBuilder<Dobavljac> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ime).IsRequired();
            builder.Property(x => x.Prezime).IsRequired();
            builder.Property(x => x.Kontakt).IsRequired();

            builder.HasMany(x => x.Porudzbine)
                .WithOne(p => p.Dobavljac)
                .HasForeignKey(p => p.IdDobavljaca)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
