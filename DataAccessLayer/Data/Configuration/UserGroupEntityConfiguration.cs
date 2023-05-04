using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKBackendInternship.DataAccessLayer.Model;

namespace VKBackendInternship.DataAccessLayer.Data.Configuration
{
    public class UserGroupEntityConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            throw new NotImplementedException();
        }
    }
}
