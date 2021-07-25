using EducationPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPortal.Persistence.EntitiesMapping
{
    public class ArticleMaterialMapping : IEntityTypeConfiguration<ArticleMaterial>
    {
        public void Configure(EntityTypeBuilder<ArticleMaterial> builder)
        {
            builder.ToTable("ArticleMaterials", "sch");

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

            builder.Property(x => x.PublicationDate)
                .HasMaxLength(256)
               .IsUnicode()
               .HasColumnName("PublicationDate")
               .IsRequired();

            builder.Property(x => x.URL)
                .HasMaxLength(256)
               .IsUnicode()
               .HasColumnName("URL")
               .IsRequired();
        }
    }
}
