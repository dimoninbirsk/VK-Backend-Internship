using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKBackendInternship.DataAccessLayer.Model;

namespace VKBackendInternship.DataAccessLayer.Data.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            throw new NotImplementedException();
        }
    }
}
