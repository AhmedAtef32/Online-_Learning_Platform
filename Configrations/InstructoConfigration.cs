using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online__Learning_Platform.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online__Learning_Platform.Configrations
{
    internal class InstructoConfigration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");
            builder.HasKey(i => i.Id);


            builder.Property(i => i.FullName).HasMaxLength(100).IsRequired();

            builder.Property(i => i.EmailAddress).HasMaxLength(100).IsRequired();

            builder.Property(i => i.ShortBio).HasMaxLength(100).IsRequired(false);

            builder.Property(i => i.JoinDate).HasDefaultValueSql("GetDate()").IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("CK_Instructors_EmailAddress", "[EmailAddress] Like '[A-Za-z0-9._%+-]%@[A-Za-z0-9.-]%.[A-Za-z][A-Za-z]%'"));


            builder.HasMany(i => i.Courses)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.InstructorId);

        }
    }
}
