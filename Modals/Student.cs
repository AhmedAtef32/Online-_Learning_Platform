using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Online__Learning_Platform.Modals
{
    internal class Student
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }


        public ICollection<StudentCourses> Enrollments { get; set; }
    }
}
