using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKBackendInternship.DataAccessLayer.Model;

namespace VKBackendInternship.DataAccessLayer.Data.Configuration
{
    public class UserStateEntityConfiguration : IEntityTypeConfiguration<UserState>
    {
        public void Configure(EntityTypeBuilder<UserState> builder)
        {
            throw new NotImplementedException();
        }
    }
}
