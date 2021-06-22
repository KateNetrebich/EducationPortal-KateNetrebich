using EducationPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Persistence.EntitiesMapping
{
    public class UsersMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_UsersId")
                .IsClustered();

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Username)
               .HasMaxLength(256)
               .IsUnicode()
               .HasColumnName("UserName")
               .IsRequired();

            builder.Property(x => x.Role)
                .HasMaxLength(256)
                .IsUnicode()
                .HasColumnName("Role")
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasMaxLength(256)
                .IsUnicode()
                .HasColumnName("PasswordHash");
        }
    }
}
