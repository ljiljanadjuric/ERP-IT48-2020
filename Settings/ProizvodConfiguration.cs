using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaObuce.Models;

namespace ProdavnicaObuce.Settings
{
    public class ProizvodConfiguration : IEntityTypeConfiguration<Proizvod>
    {
        public void Configure(EntityTypeBuilder<Proizvod> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ime).IsRequired();
            builder.Property(x => x.Cena).IsRequired();
            builder.Property(x => x.Kolicina).IsRequired();
            builder.Property(x => x.Boja).IsRequired();
            builder.Property(x => x.Brend).IsRequired();

        }
    }
}
