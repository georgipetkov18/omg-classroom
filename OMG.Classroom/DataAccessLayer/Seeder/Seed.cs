using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeder
{
    public static class Seed
    {
        #region roles, students teachers
        public static async Task SeedRolesAsync(ClassroomDbContext context)
        {
            if (await context.Roles.AnyAsync()) return;

            var roles = new List<Entities.Role>
            {
                new Entities.Role
                {
                    Id = Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"),
                    Name = "Director",
                    //ask
                    //Students = new List<Entities.Student>{ new Entities.Student { } },
                    //Teachers = new List<Entities.Teacher> { new Entities.Teacher { } }
                },
                new Entities.Role
                {
                    Id = Guid.Parse("9fc59db8-79cb-4263-9c57-cbf7c83fffc9"),
                    Name = "Student",
                    //ask
                    //Students = new List<Entities.Student>{ new Entities.Student { } },
                    //Teachers = new List<Entities.Teacher> { new Entities.Teacher { } }
                },
                new Entities.Role
                {
                    Id = Guid.Parse("e8143b76-1a82-45e7-870c-67e386381da1"),
                    Name = "Teacher",
                    //ask
                    //Students = new List<Entities.Student>{ new Entities.Student { } },
                    //Teachers = new List<Entities.Teacher> { new Entities.Teacher { } }
                },
                new Entities.Role
                {
                    Id = Guid.Parse("1a7e413a-0eb4-4c43-983b-41782d444bb5"),
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
                    Id = Guid.Parse("71a7dbfa-6489-4f91-be4e-f9c71c2faafa"),

                    Name = "Ivan Rusev",
                    Email= "rusev37@gmail.com",
                    Password= "Password123",
                    Age= 28,
                    //ask
                    RoleId=Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"),//director

                    //ask
                    //Courses = new List<Entities.Course>{ new Entities.Course() },
                    //Messages = new List<Entities.Message>{ new Entities.Message() }
                },
                new Entities.Teacher
                {
                    Id = Guid.Parse("acd7f7b7-d7dd-445c-8e49-4da42daf4591"),

                    Name = "Qroslav Petkov",
                    Email= "qroslav@gmail.com",
                    Password= "Password123",
                    Age= 27,
                    //ask
                    RoleId=Guid.Parse("e8143b76-1a82-45e7-870c-67e386381da1"),//teacher

                    //ask
                    //Courses = new List<Entities.Course>{ new Entities.Course() },
                    //Messages = new List<Entities.Message>{ new Entities.Message() }
                },
                new Entities.Teacher
                {
                    Id = Guid.Parse("a8bdd69c-b481-4da5-b657-f6d13965f106"),

                    Name = "Petko Georgiev",
                    Email= "petko@gmail.com",
                    Password= "Password123",
                    Age= 29,
                    //ask
                    RoleId= Guid.Parse("1a7e413a-0eb4-4c43-983b-41782d444bb5"),//head teacher

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
                    Id= Guid.Parse("746bce91-98ba-424d-9451-a585fe2c552b"),

                    Name = "Ivan Petrov",
                    Email= "rusev38@gmail.com",
                    Password= "Password123",
                    Age= 16,
                    //ask
                    RoleId=Guid.Parse("9fc59db8-79cb-4263-9c57-cbf7c83fffc9"),//student role

                    //ask
                    //Courses = new List<Entities.Course>{ new Entities.Course() },
                    //Messages = new List<Entities.Message>{ new Entities.Message() },

                    //Assignments = new List<Entities.Assignment>{ new Entities.Assignment() }

                },
                new Entities.Student
                {
                    Id= Guid.Parse("2d3d48c9-55ef-4ebe-8bf0-578d4165831f"),

                    Name = "Ivan Qroslavov",
                    Email= "ivanbg1@gmail.com",
                    Password= "Password123",
                    Age= 15,
                    //ask
                    RoleId=Guid.Parse("9fc59db8-79cb-4263-9c57-cbf7c83fffc9"),//student role

                    //ask
                    //Courses = new List<Entities.Course>{ new Entities.Course() },
                    //Messages = new List<Entities.Message>{ new Entities.Message() },

                    //Assignments = new List<Entities.Assignment>{ new Entities.Assignment() }

                },
                new Entities.Student
                {
                    Id= Guid.Parse("8d1be9ff-316d-4b5a-b077-b4f705f2e3a6"),

                    Name = "Ivan Gegov",
                    Email= "ivangeca2@gmail.com",
                    Password= "Password123",
                    Age= 18,
                    //ask
                    RoleId=Guid.Parse("9fc59db8-79cb-4263-9c57-cbf7c83fffc9"),//student role

                    //ask
                    //Courses = new List<Entities.Course>{ new Entities.Course() },
                    //Messages = new List<Entities.Message>{ new Entities.Message() },

                    //Assignments = new List<Entities.Assignment>{ new Entities.Assignment() }

                },
                new Entities.Student
                {
                    Id= Guid.Parse("fa197c63-e76f-4f1e-bf1a-ef2707cdc7dd"),

                    Name = "Ivan Ivanov",
                    Email= "ivanivan3@gmail.com",
                    Password= "Password123",
                    Age= 17,
                    //ask
                    RoleId=Guid.Parse("9fc59db8-79cb-4263-9c57-cbf7c83fffc9"),//student role

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
                    Id= Guid.Parse("52d80f77-1e20-46f7-93ca-ec3d7544eb54"),

                    Name = "Math",  
                    Teacher= context.Teachers.First(i=> i.Id== Guid.Parse("71a7dbfa-6489-4f91-be4e-f9c71c2faafa")),//first tacehr           
                    //ask
                    //Students = new List<Entities.User>{ new Entities.Student() },
                    //Assignments= new List<Entities.Assignment>{new Entities.Assignment() }

                },
                new Entities.Course
                {
                    Id= Guid.Parse("4cc1adca-c41e-41f0-aebf-c37dc5870c56"),

                    Name = "Bulgarian",
                    Teacher= context.Teachers.First(i=> i.Id== Guid.Parse("acd7f7b7-d7dd-445c-8e49-4da42daf4591"))//second teacher
                    //ask
                    //Students = new List<Entities.User>{ new Entities.Student() },
                    //Assignments= new List<Entities.Assignment>{new Entities.Assignment() }

                },
                new Entities.Course
                {
                    Id= Guid.Parse("2f376d85-3162-4c31-9811-88ef157b874d"),

                    Name = "English",
                    Teacher = context.Teachers.First(i=> i.Id== Guid.Parse("a8bdd69c-b481-4da5-b657-f6d13965f106")) //third teacher
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
                    Id=Guid.Parse("22a40f5c-f086-495a-92c7-7e0cfa6cc73d"),

                    Name = "Homework",
                    Description= "pages 33 to 34 from the students book",
                    IsDone= true,
                    Grade= 5.72,

                    StudentId= System.Guid.Parse("746bce91-98ba-424d-9451-a585fe2c552b"),//first student
                    CourseId = System.Guid.Parse("52d80f77-1e20-46f7-93ca-ec3d7544eb54"),//first course

                    //Messages= new List<Entities.Message>{ new Entities.Message() }
                },
                new Entities.Assignment
                {
                    Id=Guid.Parse("a175d86b-6a7f-4d1e-af9e-917b21b7cbed"),

                    Name = "Test",
                    Description= "Midterm test",
                    IsDone= true,
                    Grade= 4.92,

                    StudentId= System.Guid.Parse("2d3d48c9-55ef-4ebe-8bf0-578d4165831f"),//second student
                    CourseId = System.Guid.Parse("4cc1adca-c41e-41f0-aebf-c37dc5870c56"),//second course

                    //Messages= new List<Entities.Message>{ new Entities.Message() }
                },
                new Entities.Assignment
                {
                    Id=Guid.Parse("785edf4c-0572-4f60-a652-c151aa193d93"),

                    Name = "Project",
                    Description= "Create a presentation about the pyramids.",
                    IsDone= false,
                    //Grade= 5.72,

                    StudentId= System.Guid.Parse("8d1be9ff-316d-4b5a-b077-b4f705f2e3a6"),//third student
                    CourseId = System.Guid.Parse("2f376d85-3162-4c31-9811-88ef157b874d"),//third course

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
                    Id = Guid.Parse("f670db82-8af3-4cad-aedd-468ca1b42879"),

                    Content = "This is your homework for tommorow:",
                    CreatedDate= DateTime.Now,

                    AuthorId =Guid.Parse("71a7dbfa-6489-4f91-be4e-f9c71c2faafa"), //first teacher
                    AssignmentId = System.Guid.Parse("22a40f5c-f086-495a-92c7-7e0cfa6cc73d"),//first assignment           
                },
                new Entities.Message
                {
                    Id= Guid.Parse("7f72dc7a-4e3b-4c5d-a158-15b49fd13007"), //agent 007

                    Content = "Homework well done!",
                    CreatedDate= DateTime.Now,

                    AuthorId= Guid.Parse("acd7f7b7-d7dd-445c-8e49-4da42daf4591"), //second teacher
                    AssignmentId = System.Guid.Parse("a175d86b-6a7f-4d1e-af9e-917b21b7cbed"),//second assignment
                },
                new Entities.Message
                {
                    Id=Guid.Parse("e6259dad-3724-4994-8101-b905a55ba1eb"),

                    Content = "Homework missing!",
                    CreatedDate= DateTime.Now,

                    AuthorId = Guid.Parse("a8bdd69c-b481-4da5-b657-f6d13965f106"),//third teacher
                    AssignmentId = System.Guid.Parse("785edf4c-0572-4f60-a652-c151aa193d93"),//third assignment
                },
            };

            await context.Messages.AddRangeAsync(messages);
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
