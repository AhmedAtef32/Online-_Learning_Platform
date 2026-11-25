using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online__Learning_Platform.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online__Learning_Platform.Configrations
{
    internal class StudentConfigration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FullName).HasMaxLength(100).IsRequired();

            builder.Property(s => s.EmailAddress).HasMaxLength(100).IsRequired();

            builder.Property(s => s.DateOfBirth).IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("CK_Students_EmailAddress", "[EmailAddress] Like '[A-Za-z0-9._%+-]%@[A-Za-z0-9.-]%.[A-Za-z][A-Za-z]%'"));

            builder.HasData(
                new Student
                {
                    Id = 1,
                    FullName = "Mohamed Ali",
                    EmailAddress = "mohamed.ali@example.com",
                    DateOfBirth = new DateTime(2002, 5, 12)
                },
                new Student
                {
                    Id = 2,
                    FullName = "Sara Hassan",
                    EmailAddress = "sara.hassan@example.com",
                    DateOfBirth = new DateTime(2001, 8, 20)
                },
                new Student
                {
                    Id = 3,
                    FullName = "Omar Mahmoud",
                    EmailAddress = "omar.mahmoud@example.com",
                    DateOfBirth = new DateTime(2003, 2, 15)
                },
                new Student
                {
                    Id = 4,
                    FullName = "Nour Ahmed",
                    EmailAddress = "nour.ahmed@example.com",
                    DateOfBirth = new DateTime(2000, 11, 3)
                },
                new Student
                {
                    Id = 5,
                    FullName = "Youssef Ibrahim",
                    EmailAddress = "youssef.ibrahim@example.com",
                    DateOfBirth = new DateTime(2002, 7, 25)
                }
            );


        }
    }
}
