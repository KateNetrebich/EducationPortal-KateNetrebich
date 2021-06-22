using EducationPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Persistence.EntitiesMapping
{
    public class VideoMaterialMapping : IEntityTypeConfiguration<VideoMaterial>
    {
        public void Configure(EntityTypeBuilder<VideoMaterial> builder)
        {
            builder.ToTable("VideoMaterials", "sch");

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

            builder.Property(x => x.Duration)
                .HasMaxLength(256)
               .IsUnicode()
               .HasColumnName("Duration")
               .IsRequired();

            builder.Property(x => x.Quality)
                .HasMaxLength(256)
               .IsUnicode()
               .HasColumnName("Quality")
               .IsRequired();
        }
    }
}
