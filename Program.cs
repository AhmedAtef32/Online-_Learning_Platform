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

            //await AddInstructor(DbContext);
            //await AddCourse(DbContext);
            //await AddStudents(DbContext);
            //await EnrollStudent(DbContext);

            #endregion


            #region Read
            //await FindCourse(DbContext);
            //await FilterCourses(DbContext);
            //await PrintSubCategories(DbContext);
            //await PrintCourseRoster(DbContext);
            #endregion


            #endregion
        }

        static async Task AddInstructor(LearningPlatformDbContext dbContext)
        {
            var instructor = new Instructor
            {
                FullName = "Ahmed Mohamed",
                EmailAddress = "ahmed.mohamed@example.com",
                ShortBio = "Software engineer and programming instructor",
                JoinDate = new DateTime(2025, 1, 15)
            };

            await Helpers.AddEntity(dbContext, instructor);

            Console.WriteLine(
                $"Instructor added successfully. ID: {instructor.Id}"
            );
        }

        static async Task AddCourse(LearningPlatformDbContext dbContext)
        {
            var instructor = await dbContext.instructors.FindAsync(2);
            var category = await dbContext.categories.FindAsync(3);

            if (instructor != null && category != null)
            {
                await Helpers.AddEntity<Course>(dbContext, new Course
                {
                    Title = "SQL Server Fundamentals",
                    Description = "Learn SQL Server database development.",
                    Price = 49.99m,
                    Level = CourseLevel.Beginner,
                    IsPublished = true,
                    PublishedDate = DateTime.Now,
                    InstructorId = instructor.Id,
                    CategoryId = category.Id
                });

                Console.WriteLine("Course added successfully.");
            }
            else
            {
                Console.WriteLine("Cannot add the course: instructor or category was not found.");
            }
        }

        static async Task AddStudents(LearningPlatformDbContext dbContext)
        {
            var students = new List<Student>
            {
                new Student
                {
                    FullName = "Omar Ali",
                    EmailAddress = "omar.ali@example.com",
                    DateOfBirth = new DateTime(2002, 5, 10)
                },

                new Student
                {
                    FullName = "Sara Mohamed",
                    EmailAddress = "sara.mohamed@example.com",
                    DateOfBirth = new DateTime(2001, 8, 20)
                },

                new Student
                {
                    FullName = "Youssef Ahmed",
                    EmailAddress = "youssef.ahmed@example.com",
                    DateOfBirth = new DateTime(2003, 2, 15)
                }
            };

            await Helpers.AddRangeEntities(dbContext, students);

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"Student added: {student.FullName}, ID: {student.Id}"
                );
            }
        }

        static async Task EnrollStudent(LearningPlatformDbContext dbContext)
        {
            int studentId = 7;
            int courseId = 2;

            var student = await dbContext.students.FindAsync(studentId);

            if (student != null)
            {
                var course = await dbContext.courses.FindAsync(courseId);

                if (course != null)
                {
                    bool isEnrolled = await dbContext.studentCourses
                        .AnyAsync(sc => sc.StudentId == student.Id &&
                                        sc.CourseId == course.Id);

                    if (!isEnrolled && course.IsPublished)
                    {
                        var enrollment = new StudentCourses
                        {
                            StudentId = student.Id,
                            CourseId = course.Id,
                            EnrollmentDate = DateTime.Now,
                            ProgressPercentage = 0,
                            Status = StudentCoursesStatus.Active,
                            FinalGrade = null
                        };

                        await Helpers.AddEntity<StudentCourses>(
                            dbContext,
                            enrollment
                        );

                        Console.WriteLine("Student enrolled successfully.");
                    }
                    else if (isEnrolled)
                    {
                        Console.WriteLine("Enrollment refused: Student is already enrolled.");
                    }
                    else
                    {
                        Console.WriteLine("Enrollment refused: Course is not published.");
                    }
                }
                else
                {
                    Console.WriteLine("Enrollment refused: Course not found.");
                }
            }
            else
            {
                Console.WriteLine("Enrollment refused: Student not found.");
            }
        }


        static async Task FindCourse(LearningPlatformDbContext dbContext)
        {
            // Find course by Id using FindAsync
            var courseById = await dbContext.courses.FindAsync(2);

            if (courseById != null)
            {
                Console.WriteLine(
                    $"Course found by Id: {courseById.Title}, Price: {courseById.Price}"
                );
            }
            else
            {
                Console.WriteLine("Course not found.");
            }

            // Find course by Title using FirstOrDefaultAsync
            var courseByTitle = await dbContext.courses
                .FirstOrDefaultAsync(c => c.Title == "SQL Server Fundamentals");

            if (courseByTitle != null)
            {
                Console.WriteLine(
                    $"Course found by Title: {courseByTitle.Title}, Price: {courseByTitle.Price}"
                );
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        static async Task FilterCourses(LearningPlatformDbContext dbContext)
        {
            var Courses = await dbContext.courses
                .Where(c => c.Price >= 20 && c.Price <= 40)
                .OrderByDescending(c => c.Price)
                .ToListAsync();

            foreach (var course in Courses)
            {
                Console.WriteLine(
                    $"Title: {course.Title}, Level: {course.Level}, Price: {course.Price}"
                );
            }
        }

        static async Task PrintSubCategories(LearningPlatformDbContext dbContext)
        {
            int categoryId = 2;

            var SubCategories = await dbContext.categories
                .Where(c => c.ParentCategoryId == categoryId)
                .ToListAsync();

            Console.WriteLine("SubCategories :");
            foreach (var category in SubCategories)
            {
                Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
            }

            var TopLevelCategories = await dbContext.categories
                .Where(c => c.ParentCategoryId == null)
                .ToListAsync();

            Console.WriteLine("TopLevelCategories :");

            foreach (var category in TopLevelCategories)
            {
                Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
            }
        }

        static async Task PrintCourseRoster(LearningPlatformDbContext dbContext)
        {
            var courses = await dbContext.courses.ToListAsync();

            foreach (var course in courses)
            {
                var StudentIds = await dbContext.studentCourses
                    .Where(sc => sc.CourseId == course.Id)
                    .Select(sc => sc.StudentId)
                    .ToListAsync();

                var Students = await dbContext.students
                    .Where(s => StudentIds.Contains(s.Id))
                    .ToListAsync();

                Console.WriteLine($"Course: {course.Title}");
                Console.WriteLine($"Number of enrolled students: {Students.Count}");

                foreach (var student in Students)
                {
                    Console.WriteLine($"Student: {student.FullName}");
                }

                Console.WriteLine("============================");

            }
        }


    }
}
