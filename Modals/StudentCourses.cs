using Online__Learning_Platform.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Online__Learning_Platform.Modals
{
    internal class StudentCourses
    {

        public int StudentId { get; set; }

        public Student student { get; set; }


        public int CourseId { get; set; }
        public Course Course { get; set; }



        public DateTime EnrollmentDate { get; set; }

        public decimal ProgressPercentage { get; set; }
        public StudentCoursesStatus Status{ get; set; }
        public decimal? FinalGrade{ get; set; }
    }
}
