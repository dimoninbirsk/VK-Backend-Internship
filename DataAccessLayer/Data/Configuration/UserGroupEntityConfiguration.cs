using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKBackendInternship.DataAccessLayer.Model;

namespace VKBackendInternship.DataAccessLayer.Data.Configuration
{
    public class UserGroupEntityConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder
                .ToTable("user_group");

            builder.Property(group => group.Role)
                .IsRequired()
                .HasColumnName("code");

            builder.Property(group => group.Description)
                .IsRequired()
                .HasColumnName("description");
        }
    }
}
