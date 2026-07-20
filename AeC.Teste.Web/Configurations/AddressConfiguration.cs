using AeC.Teste.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeC.Teste.Web.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cep)
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(x => x.Street)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Complement)
                .HasMaxLength(200);

            builder.Property(x => x.District)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.City)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.State)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(x => x.Number)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
