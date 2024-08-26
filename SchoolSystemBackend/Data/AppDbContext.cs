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
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ClassStream> ClassStreams { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //auto id
            modelBuilder.Entity<AppUser>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ClassStream>()
                .HasMany(e => e.Grades)
                .WithOne(g => g.ClassStream)
                .HasForeignKey(g => g.GradeId);
            modelBuilder.Entity<Student>()
                .HasMany(e => e.NextOfKins)
                .WithMany(e => e.Students)
                .UsingEntity(j=>j.ToTable("StudentNextOfKins"));

            base.OnModelCreating(modelBuilder);

        }
    }
}
