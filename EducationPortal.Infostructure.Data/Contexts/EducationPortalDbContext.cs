using EducationPortal.Data.Entities;
using EducationPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Reflection;

namespace EducationPortal.Persistence.Contexts
{
    public class EducationPortalDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public EducationPortalDbContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        public DbSet<CourseMaterial> CourseMaterial { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<VideoMaterial> VideoMaterials { get; set; }
        public DbSet<BookMaterial> BookMaterials { get; set; }
        public DbSet<ArticleMaterial> ArticleMaterials { get; set; }


        public EducationPortalDbContext(DbContextOptions<EducationPortalDbContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sch");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
