using EducationPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPortal.Persistence.EntitiesMapping
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_CourseId")
                .IsClustered();

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsUnicode()
                .HasColumnName("CourseName")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(256)
                .IsUnicode()
                .HasColumnName("Description")
                .IsRequired();

            builder.Property(x => x.Skills)
                .HasMaxLength(256)
                .IsUnicode()
                .HasColumnName("Skills")
                .IsRequired();

            builder.HasMany(x => x.Materials)
               .WithMany(x => x.Courses)
               .UsingEntity<CourseMaterial>(x => x
                   .HasOne(x => x.Material)
                   .WithMany()
                   .HasForeignKey(x => x.MaterialId),
                   x => x
                   .HasOne(x => x.Course)
                   .WithMany()
                   .HasForeignKey(x => x.CourseId),
                   x =>
                   {
                       x.HasKey(x => new { x.CourseId, x.MaterialId });
                       x.ToTable("CourseMaterial");
                   });
        }
    }
}
