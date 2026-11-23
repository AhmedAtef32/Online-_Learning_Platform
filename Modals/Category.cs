using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Online__Learning_Platform.Modals
{
    internal class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }

        public Category? ParentCategory { get; set; }

        public ICollection<Category> Subcategories { get; set; }
            = new List<Category>();


        public ICollection<Course> Courses { get; set; }
    }
}
