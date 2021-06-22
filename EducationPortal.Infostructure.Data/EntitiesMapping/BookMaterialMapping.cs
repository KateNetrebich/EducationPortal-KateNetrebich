using EducationPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Persistence.EntitiesMapping
{
    public class BookMaterialMapping : IEntityTypeConfiguration<BookMaterial>
    {
        public void Configure(EntityTypeBuilder<BookMaterial> builder)
        {
            builder.ToTable("BookMaterials", "sch");

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

            builder.Property(x=>x.YearOfPublication)
                .HasMaxLength(256)
               .IsUnicode()
               .HasColumnName("YearOfPublication")
               .IsRequired();
        }
    }
}
