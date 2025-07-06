using Microsoft.EntityFrameworkCore;
using Mission.Entity.Model;

namespace Mission.Entity
{
    public class MissionDbContext : DbContext
    {
        public MissionDbContext(DbContextOptions<MissionDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Chintan",
                LastName = "Parmar",
                Email = "chintan@gmail.com",
                Password = "admin@123",
                PhoneNumber = "9999999999",
                UserType = "admin",
                UserImage = string.Empty
            });
        }
    }
}
