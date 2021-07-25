using EducationPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPortal.Persistence.EntitiesMapping
{
    public class CourseResultMapping : IEntityTypeConfiguration<CourseResult>
    {
        public void Configure(EntityTypeBuilder<CourseResult> builder)
        {
            builder.HasKey(x => new { x.CourseId, x.UserId });

            builder.HasOne(x => x.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseId)
                .HasConstraintName("FK_CourseResult_Course_CourseId")
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_Courseresult_User_UserId")
                .IsRequired();
        }
    }
}
