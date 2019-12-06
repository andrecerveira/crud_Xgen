using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.EntityConfig
{
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
