using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online__Learning_Platform.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online__Learning_Platform.Configrations
{
    internal class StudentCoursesConfigration : IEntityTypeConfiguration<StudentCourses>
    {
        public void Configure(EntityTypeBuilder<StudentCourses> builder)
        {
            builder.ToTable("StudentCourses");
            builder.HasKey(s => new { s.StudentId  , s.CourseId});

            builder.Property(s => s.EnrollmentDate).HasDefaultValueSql("GetDate()").IsRequired();

            builder.Property(s => s.ProgressPercentage).HasPrecision(5,2).IsRequired();

            builder.Property(s => s.Status).HasMaxLength(20).HasConversion<string>().IsRequired();

            builder.Property(s => s.FinalGrade).HasPrecision(5, 2).IsRequired(false);

            builder.ToTable( t => t.HasCheckConstraint("CK_StudentCourses_Progress","[ProgressPercentage] >= 0 AND [ProgressPercentage] <= 100"));

            builder.HasOne(sc => sc.student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(sc=>sc.StudentId);

            builder.HasOne(sc => sc.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(sc=>sc.CourseId);

        }
    }
}
