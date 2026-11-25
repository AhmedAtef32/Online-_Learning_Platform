using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Online__Learning_Platform.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Programming languages and software development.", "Programming", null },
                    { 3, "Database design and management.", "Database", null }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "EmailAddress", "FullName", "JoinDate", "ShortBio" },
                values: new object[,]
                {
                    { 1, "ahmed.mohamed@example.com", "Ahmed Mohamed", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software engineer and instructor specializing in web development." },
                    { 2, "sara.ahmed@example.com", "Sara Ahmed", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Experienced instructor in database design and SQL." },
                    { 3, "omar.hassan@example.com", "Omar Hassan", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full-stack developer specializing in ASP.NET Core and Angular." }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "EmailAddress", "FullName" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohamed.ali@example.com", "Mohamed Ali" },
                    { 2, new DateTime(2001, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.hassan@example.com", "Sara Hassan" },
                    { 3, new DateTime(2003, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.mahmoud@example.com", "Omar Mahmoud" },
                    { 4, new DateTime(2000, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "nour.ahmed@example.com", "Nour Ahmed" },
                    { 5, new DateTime(2002, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.ibrahim@example.com", "Youssef Ibrahim" }
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Frontend and backend web development.", "Web Development", 1 },
                    { 6, "Microsoft SQL Server database management and development.", "SQL Server", 3 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[] { 1, 1, "Learn the fundamentals of C# programming.", 1, true, "Beginner", 49.99m, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Fundamentals" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 4, "Building user interfaces for web applications.", "Frontend Development", 2 },
                    { 5, "Server-side development and API design.", "Backend Development", 2 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 2, 2, "Build RESTful APIs using ASP.NET Core.", 2, true, "Intermediate", 79.99m, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core Web API" },
                    { 3, 2, "Explore advanced EF Core features and performance.", 1, false, "Advanced", 99.99m, null, "Advanced Entity Framework Core" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId", "EnrollmentDate", "FinalGrade", "ProgressPercentage", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.00m, 100.00m, "Completed" },
                    { 1, 2, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88.50m, 100.00m, "Completed" },
                    { 1, 4, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 91.25m, 100.00m, "Completed" },
                    { 2, 1, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 65.50m, "Active" },
                    { 3, 2, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20.00m, "Dropped" },
                    { 2, 3, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 45.75m, "Active" },
                    { 3, 5, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.00m, "Active" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
