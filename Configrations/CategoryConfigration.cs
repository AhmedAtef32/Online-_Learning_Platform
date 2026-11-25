using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online__Learning_Platform.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online__Learning_Platform.Configrations
{
    internal class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categorys");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(250).IsRequired(false);

            builder.HasOne(c => c.ParentCategory)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Programming",
                    Description = "Programming languages and software development.",
                    ParentCategoryId = null
                },
                new Category
                {
                    Id = 2,
                    Name = "Web Development",
                    Description = "Frontend and backend web development.",
                    ParentCategoryId = 1
                },
                new Category
                {
                    Id = 3,
                    Name = "Database",
                    Description = "Database design and management.",
                    ParentCategoryId = null
                },
                new Category
                {
                    Id = 4,
                    Name = "Frontend Development",
                    Description = "Building user interfaces for web applications.",
                    ParentCategoryId = 2
                },
                new Category
                {
                    Id = 5,
                    Name = "Backend Development",
                    Description = "Server-side development and API design.",
                    ParentCategoryId = 2
                },
                new Category
                {
                    Id = 6,
                    Name = "SQL Server",
                    Description = "Microsoft SQL Server database management and development.",
                    ParentCategoryId = 3
                }
            );


        }
    }
}
