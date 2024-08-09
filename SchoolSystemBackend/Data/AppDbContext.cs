using Microsoft.EntityFrameworkCore;
using SchoolSystemBackend.Models.Entities;

namespace SchoolSystemBackend.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().ToTable("AppUsers");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Staff>().ToTable("Staff");
            //auto id
            modelBuilder.Entity<AppUser>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }
    }
}
