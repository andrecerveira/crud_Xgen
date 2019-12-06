using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.EntityConfig
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.PublicPlace)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Complement)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(c => c.Client)
                .WithMany()
                .HasForeignKey(c => c.ClientId);
        }
    }
}
