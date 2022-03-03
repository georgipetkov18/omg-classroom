using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeder
{
    public class Seed
    {
        #region roles, students teachers
        public static async Task SeedRolesAsync(ClassroomDbContext context)
        {
            if (await context.Roles.AnyAsync()) return;

            var roles = new List<Entities.Role>
            {
                new Entities.Role
                {
                    //Id = Guid.NewGuid(),
                    Name = "Director",
                    //ask
                    //Students = new List<Entities.Student>{ new Entities.Student { } },
                    //Teachers = new List<Entities.Teacher> { new Entities.Teacher { } }
                },
                new Entities.Role
                {
                    //Id = Guid.NewGuid(),
                    Name = "Student",
                    //ask
                    //Students = new List<Entities.Student>{ new Entities.Student { } },
                    //Teachers = new List<Entities.Teacher> { new Entities.Teacher { } }
                },
                new Entities.Role
                {
                    //Id = Guid.NewGuid(),
                    Name = "Teacher",
                    //ask
                    //Students = new List<Entities.Student>{ new Entities.Student { } },
                    //Teachers = new List<Entities.Teacher> { new Entities.Teacher { } }
                },
                new Entities.Role
                {
                    //Id = Guid.NewGuid(),
                    Name = "Head Teacher",
                    //ask
                    //Students = new List<Entities.Student>{ new Entities.Student { } },
                    //Teachers = new List<Entities.Teacher> { new Entities.Teacher { } }
                }
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }
        public static async Task SeedTeachersAsync(ClassroomDbContext context)
        {
            if (await context.Teachers.AnyAsync()) return;

            var teachers = new List<Entities.Teacher>
            {
                new Entities.Teacher
                {
                    Name = "Ivan Rusev",
                    Email= "rusev37@gmail.com",
                    Password= "Password123",
                    Age= 28,
                    //ask
                    RoleId=System.Guid.Parse("0"),

                    //ask
                    //Courses = new List<Entities.Course>{ new Entities.Course() },
                    //Messages = new List<Entities.Message>{ new Entities.Message() }
                },
                new Entities.Teacher
                {
                    Name = "Qroslav Petkov",
                    Email= "qroslav@gmail.com",
                    Password= "Password123",
                    Age= 27,
                    //ask
                    RoleId=System.Guid.Parse("2"),

                    //ask
                    //Courses = new List<Entities.Course>{ new Entities.Course() },
                    //Messages = new List<Entities.Message>{ new Entities.Message() }
                },
                new Entities.Teacher
                {
                    Name = "Petko Georgiev",
                    Email= "petko@gmail.com",
                    Password= "Password123",
                    Age= 29,
                    //ask
                    RoleId=System.Guid.Parse("3"),

                    //ask
                    //Courses = new List<Entities.Course>{ new Entities.Course() },
                    //Messages = new List<Entities.Message>{ new Entities.Message() }
                }
            };

            await context.Teachers.AddRangeAsync(teachers);
            await context.SaveChangesAsync();
        }
        public static async Task SeedStudentsAsync(ClassroomDbContext context)
        {
            if (await context.Students.AnyAsync()) return;

            var students = new List<Entities.Student>
            {
                new Entities.Student
                {
                    Name = "Ivan Petrov",
                    Email= "rusev38@gmail.com",
                    Password= "Password123",
                    Age= 16,
                    //ask
                    RoleId=System.Guid.Parse("1"),

                    //ask
                    //Courses = new List<Entities.Course>{ new Entities.Course() },
                    //Messages = new List<Entities.Message>{ new Entities.Message() },

                    //Assignments = new List<Entities.Assignment>{ new Entities.Assignment() }

                },
                new Entities.Student
                {
                    Name = "Ivan Qroslavov",
                    Email= "ivanbg1@gmail.com",
                    Password= "Password123",
                    Age= 15,
                    //ask
                    RoleId=System.Guid.Parse("1"),

                    //ask
                    //Courses = new List<Entities.Course>{ new Entities.Course() },
                    //Messages = new List<Entities.Message>{ new Entities.Message() },

                    //Assignments = new List<Entities.Assignment>{ new Entities.Assignment() }

                },
                new Entities.Student
                {
                    Name = "Ivan Gegov",
                    Email= "ivangeca2@gmail.com",
                    Password= "Password123",
                    Age= 18,
                    //ask
                    RoleId=System.Guid.Parse("1"),

                    //ask
                    //Courses = new List<Entities.Course>{ new Entities.Course() },
                    //Messages = new List<Entities.Message>{ new Entities.Message() },

                    //Assignments = new List<Entities.Assignment>{ new Entities.Assignment() }

                },
                new Entities.Student
                {
                    Name = "Ivan Ivanov",
                    Email= "ivanivan3@gmail.com",
                    Password= "Password123",
                    Age= 17,
                    //ask
                    RoleId=System.Guid.Parse("1"),

                    //ask
                    //Courses = new List<Entities.Course>{ new Entities.Course() },
                    //Messages = new List<Entities.Message>{ new Entities.Message() },

                    //Assignments = new List<Entities.Assignment>{ new Entities.Assignment() }

                }

            };

            await context.Students.AddRangeAsync(students);
            await context.SaveChangesAsync();
        }
        #endregion
        #region courses, assigments and messages
        public static async Task SeedCoursesAsync(ClassroomDbContext context)
        {
            if (await context.Courses.AnyAsync()) return;

            var courses = new List<Entities.Course>
            {
                new Entities.Course
                {
                    Name = "Math",                 
                    TeacherId= 0,
                    //ask
                    //Students = new List<Entities.User>{ new Entities.Student() },
                    //Assignments= new List<Entities.Assignment>{new Entities.Assignment() }

                },
                new Entities.Course
                {
                    Name = "Bulgarian",
                    TeacherId= 1,
                    //ask
                    //Students = new List<Entities.User>{ new Entities.Student() },
                    //Assignments= new List<Entities.Assignment>{new Entities.Assignment() }

                },
                new Entities.Course
                {
                    Name = "English",
                    TeacherId= 2,
                    //ask
                    //Students = new List<Entities.User>{ new Entities.Student() },
                    //Assignments= new List<Entities.Assignment>{new Entities.Assignment() }

                }

            };

            await context.Courses.AddRangeAsync(courses);
            await context.SaveChangesAsync();
        }
        public static async Task SeedAssignmentsAsync(ClassroomDbContext context)
        {
            if (await context.Assignments.AnyAsync()) return;

            var assignments = new List<Entities.Assignment>
            {
                new Entities.Assignment
                {
                    Name = "Homework",
                    Description= "pages 33 to 34 from the students book",
                    IsDone= true,
                    Grade= 5.72,

                    StudentId= System.Guid.Parse("0"),
                    CourseId = System.Guid.Parse("0"),

                    //Messages= new List<Entities.Message>{ new Entities.Message() }
                },
                new Entities.Assignment
                {
                    Name = "Test",
                    Description= "Midterm test",
                    IsDone= true,
                    Grade= 4.92,

                    StudentId= System.Guid.Parse("1"),
                    CourseId = System.Guid.Parse("1"),

                    //Messages= new List<Entities.Message>{ new Entities.Message() }
                },
                new Entities.Assignment
                {
                    Name = "Project",
                    Description= "Create a presentation about the pyramids.",
                    IsDone= false,
                    //Grade= 5.72,

                    StudentId= System.Guid.Parse("2"),
                    CourseId = System.Guid.Parse("2"),

                    //Messages= new List<Entities.Message>{ new Entities.Message() }
                },

            };

            await context.Assignments.AddRangeAsync(assignments);
            await context.SaveChangesAsync();
        }
        public static async Task SeedMessagesAsync(ClassroomDbContext context)
        {
            if (await context.Messages.AnyAsync()) return;

            var messages = new List<Entities.Message>
            {
                new Entities.Message
                {
                    Content = "This is your homework for tommorow:",
                    CreatedDate= DateTime.Now,

                    UserId= 0,
                    AssignmentId = System.Guid.Parse("0"),                   
                },
                new Entities.Message
                {
                    Content = "Homework well done!",
                    CreatedDate= DateTime.Now,

                    UserId= 1,
                    AssignmentId = System.Guid.Parse("1"),
                },
                new Entities.Message
                {
                    Content = "Homework missing!",
                    CreatedDate= DateTime.Now,

                    UserId= 2,
                    AssignmentId = System.Guid.Parse("2"),
                },
            };

            await context.Messages.AddRangeAsync(messages);
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
