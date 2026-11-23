using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Online__Learning_Platform.Modals
{
    internal class Instructor
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string? ShortBio { get; set; }
        public DateTime JoinDate { get; set; }


        public ICollection<Course> Courses { get; set; } = new HashSet<Course> { };
    }
}
