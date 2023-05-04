using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VKBackendInternship.DataAccessLayer.Data.Configuration;
using VKBackendInternship.DataAccessLayer.Model;

namespace VKBackendInternship.DataAccessLayer.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UsersGroup { get; set; }
        public DbSet<UserState> UsersState { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserGroupEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserStateEntityConfiguration());
        }
    }
}
