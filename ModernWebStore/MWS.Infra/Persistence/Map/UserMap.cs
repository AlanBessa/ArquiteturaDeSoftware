using MWS.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace MWS.Infra.Persistence.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            HasKey(x => x.Id);

            Property(x => x.Email)
                .HasMaxLength(160)
                .IsRequired();

            Property(x => x.Password)
                .HasMaxLength(32)
                .IsFixedLength()
                .IsRequired();

            Property(x => x.IsAdmin)
                .IsRequired();
        }
    }
}