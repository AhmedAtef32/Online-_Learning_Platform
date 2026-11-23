using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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



        }
    }
}
