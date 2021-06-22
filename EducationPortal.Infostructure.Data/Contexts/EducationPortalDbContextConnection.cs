using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;


namespace EducationPortal.Persistence.Contexts
{
    public class EducationPortalDbContextConnection : IDesignTimeDbContextFactory<EducationPortalDbContext>
    {
        public EducationPortalDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EducationPortalDbContext>()
                .UseSqlServer(@"Server=LAPTOP-IO7I9C50;Database=EducationPortalDb;Trusted_Connection=True;",
                    o =>
                    {
                        o.MigrationsHistoryTable("Migrations", "sch");
                        o.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    }).EnableSensitiveDataLogging();

            return new EducationPortalDbContext(optionsBuilder.Options);
        }
    }
}
