using Microsoft.EntityFrameworkCore;
using Online__Learning_Platform.Contexts;
using Online__Learning_Platform.Enums;
using Online__Learning_Platform.Helper;
using Online__Learning_Platform.Modals;
namespace Online__Learning_Platform
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using LearningPlatformDbContext DbContext = new();


            #region Part 02: Operations


            #region Create


            //===========================================

            //await Helpers.AddEntity<Instructor>(DbContext, new Instructor
            //{
            //    FullName = "Ahmed Mohamed",
            //    EmailAddress = "ahmed.mohamed@example.com",
            //    ShortBio = "Software engineer and programming instructor",
            //    JoinDate = new DateTime(2025, 1, 15)
            //});

            //===========================================

            //var instructor = await DbContext.instructors.FindAsync(2);
            //var category = await DbContext.categories.FindAsync(3);

            //if (instructor != null && category != null)
            //{
            //    await Helpers.AddEntity<Course>(DbContext, new Course
            //    {
            //        Title = "SQL Server Fundamentals",
            //        Description = "Learn SQL Server database development.",
            //        Price = 49.99m,
            //        Level = CourseLevel.Beginner,
            //        IsPublished = true,
            //        PublishedDate = DateTime.Now,
            //        InstructorId = instructor.Id,
            //        CategoryId = category.Id
            //    });

            //    Console.WriteLine("Course added successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Cannot add the course: instructor or category was not found.");
            //}

            //===========================================

            //var students = new List<Student>
            //{
            //    new Student
            //    {
            //        FullName = "Ali Mohamed",
            //        EmailAddress = "ali@example.com",
            //        DateOfBirth = new DateTime(2002, 5, 10)
            //    },
            //    new Student
            //    {
            //        FullName = "Omar Ahmed",
            //        EmailAddress = "omar@example.com",
            //        DateOfBirth = new DateTime(2001, 8, 15)
            //    },
            //    new Student
            //    {
            //        FullName = "Sara Hassan",
            //        EmailAddress = "sara@example.com",
            //        DateOfBirth = new DateTime(2003, 3, 20)
            //    }
            //};

            //await Helpers.AddRangeEntities(DbContext, students);

            //foreach (var student in students)
            //{
            //    Console.WriteLine($"Student added: {student.FullName}, ID: {student.Id}");
            //}

            //===========================================

            //var student = await DbContext.students.FindAsync(7);
            //var course = await DbContext.courses.FindAsync(2);

            //if (student != null && course != null)
            //{
            //    bool isEnrolled = await DbContext.studentCourses
            //        .AnyAsync(sc => sc.StudentId == student.Id &&
            //                        sc.CourseId == course.Id);

            //    if (!isEnrolled && course.IsPublished)
            //    {
            //        var enrollment = new StudentCourses
            //        {
            //            StudentId = student.Id,
            //            CourseId = course.Id,
            //            EnrollmentDate = DateTime.Now,
            //            ProgressPercentage = 0,
            //            Status = StudentCoursesStatus.Active,
            //            FinalGrade = null
            //        };

            //        await Helpers.AddEntity<StudentCourses>(DbContext, enrollment);

            //        Console.WriteLine("Student enrolled successfully.");
            //    }
            //    else if (isEnrolled)
            //    {
            //        Console.WriteLine("Enrollment refused: Student is already enrolled.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Enrollment refused: Course is not published.");
            //    }
            //}
            //else if (student == null)
            //{
            //    Console.WriteLine("Enrollment refused: Student not found.");
            //}
            //else
            //{
            //    Console.WriteLine("Enrollment refused: Course not found.");
            //}
            //===========================================




            #endregion


            #endregion
        }
    }
}
