using EducationPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.Property(x => x.Password)
                .HasMaxLength(256)
                .IsUnicode()
                .HasColumnName("PasswordHash");
        }
    }
}
