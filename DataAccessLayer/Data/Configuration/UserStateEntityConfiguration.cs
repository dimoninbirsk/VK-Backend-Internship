using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKBackendInternship.DataAccessLayer.Model;

namespace VKBackendInternship.DataAccessLayer.Data.Configuration
{
    public class UserStateEntityConfiguration : IEntityTypeConfiguration<UserState>
    {
        public void Configure(EntityTypeBuilder<UserState> builder)
        {
            builder
                .ToTable("user_state")
                .HasKey(state => state.Id)
                .HasName("id");

            builder.Property(state => state.Status)
                .IsRequired()
                .HasColumnName("code");

            builder.Property(state => state.Description)
                .IsRequired()
                .HasColumnName("description");
        }
    }
}
