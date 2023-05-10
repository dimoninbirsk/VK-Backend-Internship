using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKBackendInternship.DataAccessLayer.Model;

namespace VKBackendInternship.DataAccessLayer.Data.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("user")
                .HasKey(user => user.Id);

            builder.HasOne(user => user.Group);
            builder.HasOne(user => user.State);

            builder.Property(user => user.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(user => user.Login)
                .IsRequired()
                .HasColumnName("login");

            builder.Property(user => user.Password)
                .IsRequired()
                .HasColumnName("password");

            builder.Property(user => user.DateOfCreation)
                .IsRequired()
                .HasColumnName("created_date");

            builder.Property(user=> user.GroupId)
                .HasColumnName("user_group_id");

            builder.Property(user => user.StateId)
                .HasColumnName("user_state_id");
        }
    }
}
