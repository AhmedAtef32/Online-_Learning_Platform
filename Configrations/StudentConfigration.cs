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



        }
    }
}
