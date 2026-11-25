using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online__Learning_Platform.Enums;
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
            builder.HasKey(s => new { s.StudentId, s.CourseId });

            builder.Property(s => s.EnrollmentDate).HasDefaultValueSql("GetDate()").IsRequired();

            builder.Property(s => s.ProgressPercentage).HasPrecision(5, 2).IsRequired();

            builder.Property(s => s.Status).HasMaxLength(20).HasConversion<string>().IsRequired();

            builder.Property(s => s.FinalGrade).HasPrecision(5, 2).IsRequired(false);

            builder.ToTable(t => t.HasCheckConstraint("CK_StudentCourses_Progress", "[ProgressPercentage] >= 0 AND [ProgressPercentage] <= 100"));

            builder.HasOne(sc => sc.student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(sc => sc.StudentId);

            builder.HasOne(sc => sc.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(sc => sc.CourseId);


            builder.HasData(
                new StudentCourses
                {
                    StudentId = 1,
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2025, 1, 20),
                    ProgressPercentage = 100.00m,
                    Status = StudentCoursesStatus.Completed,
                    FinalGrade = 95.00m
                },
                new StudentCourses
                {
                    StudentId = 1,
                    CourseId = 2,
                    EnrollmentDate = new DateTime(2025, 2, 15),
                    ProgressPercentage = 65.50m,
                    Status = StudentCoursesStatus.Active,
                    FinalGrade = null
                },
                new StudentCourses
                {
                    StudentId = 2,
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2025, 3, 1),
                    ProgressPercentage = 100.00m,
                    Status = StudentCoursesStatus.Completed,
                    FinalGrade = 88.50m
                },
                new StudentCourses
                {
                    StudentId = 2,
                    CourseId = 3,
                    EnrollmentDate = new DateTime(2025, 4, 10),
                    ProgressPercentage = 20.00m,
                    Status = StudentCoursesStatus.Dropped,
                    FinalGrade = null
                },
                new StudentCourses
                {
                    StudentId = 3,
                    CourseId = 2,
                    EnrollmentDate = new DateTime(2025, 5, 5),
                    ProgressPercentage = 45.75m,
                    Status = StudentCoursesStatus.Active,
                    FinalGrade = null
                },
                new StudentCourses
                {
                    StudentId = 4,
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2025, 6, 12),
                    ProgressPercentage = 100.00m,
                    Status = StudentCoursesStatus.Completed,
                    FinalGrade = 91.25m
                },
                new StudentCourses
                {
                    StudentId = 5,
                    CourseId = 3,
                    EnrollmentDate = new DateTime(2025, 7, 1),
                    ProgressPercentage = 0.00m,
                    Status = StudentCoursesStatus.Active,
                    FinalGrade = null
                }
            );


        }
    }
}
