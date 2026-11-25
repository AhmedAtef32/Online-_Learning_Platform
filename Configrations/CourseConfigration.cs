using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online__Learning_Platform.Enums;
using Online__Learning_Platform.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online__Learning_Platform.Configrations
{
    internal class CourseConfigration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title).HasMaxLength(50).IsRequired();

            builder.Property(c => c.Description).HasMaxLength(250).IsRequired(false);

            builder.Property(c => c.Price).HasPrecision(10, 2).IsRequired();

            builder.Property(c => c.Level).HasMaxLength(20).HasConversion<string>().IsRequired();

            builder.Property(c => c.IsPublished).IsRequired();

            builder.Property(c => c.PublishedDate).IsRequired(false);

            builder.HasOne(course => course.Category)
                .WithMany(Category => Category.Courses)
                .HasForeignKey(course => course.CategoryId);


            builder.HasData(
                new Course
                {
                    Id = 1,
                    Title = "C# Fundamentals",
                    Description = "Learn the fundamentals of C# programming.",
                    Price = 49.99m,
                    Level = CourseLevel.Beginner,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 1, 15),
                    CategoryId = 1,
                    InstructorId = 1
                },
                new Course
                {
                    Id = 2,
                    Title = "ASP.NET Core Web API",
                    Description = "Build RESTful APIs using ASP.NET Core.",
                    Price = 79.99m,
                    Level = CourseLevel.Intermediate,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 3, 10),
                    CategoryId = 2,
                    InstructorId = 2
                },
                new Course
                {
                    Id = 3,
                    Title = "Advanced Entity Framework Core",
                    Description = "Explore advanced EF Core features and performance.",
                    Price = 99.99m,
                    Level = CourseLevel.Advanced,
                    IsPublished = false,
                    PublishedDate = null,
                    CategoryId = 2,
                    InstructorId = 1
                }
            );


        }
    }
}
