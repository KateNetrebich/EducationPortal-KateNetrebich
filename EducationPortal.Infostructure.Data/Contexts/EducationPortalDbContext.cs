using EducationPortal.Data.Entities;
using EducationPortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EducationPortal.Persistence.Contexts
{
    public class EducationPortalDbContext : DbContext
    {
        public EducationPortalDbContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<VideoMaterial> VideoMaterials { get; set; }
        public DbSet<BookMaterial> BookMaterials { get; set; }
        public DbSet<ArticleMaterial> ArticleMaterials { get; set; }


        public EducationPortalDbContext(DbContextOptions<EducationPortalDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sch");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
