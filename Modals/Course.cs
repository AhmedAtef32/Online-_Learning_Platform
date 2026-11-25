using Online__Learning_Platform.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Online__Learning_Platform.Modals
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public CourseLevel Level{ get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedDate { get; set; }


        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }


        public int CategoryId { get; set; }

        public Category Category { get; set; }


        public ICollection<StudentCourses> Enrollments { get; set; } = new HashSet<StudentCourses>();



    }
}
