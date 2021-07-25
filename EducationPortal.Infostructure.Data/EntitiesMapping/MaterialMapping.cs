using EducationPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPortal.Persistence.EntitiesMapping
{
    public class MaterialMapping : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Materials", "sch");

            builder.HasKey(x => x.Id).IsClustered();

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
               .HasMaxLength(256)
               .IsUnicode()
               .HasColumnName("Name")
               .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(256)
                .IsUnicode()
                .HasColumnName("Description")
                .IsRequired();
        }
    }
}
