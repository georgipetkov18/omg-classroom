using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Mappers;
using DataAccessLayer.Repositories.StudentRepositories;
using DataAccessLayer.Seeder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataAccessLayer.Repositories.Tests
{
    public class StudentRepositoryTests
    {
        private readonly DbContextOptions<ClassroomDbContext> dbContextOptions;
        private readonly ClassroomDbContext context;
        private readonly IMapper _mapper;
        private readonly StudentRepository repository;

        public async void Dispose()
        {
            await context.Database.EnsureDeletedAsync();
        }

        public StudentRepositoryTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<ClassroomDbContext>()
                .UseInMemoryDatabase(databaseName: "reposdb").Options;

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            context = new ClassroomDbContext(dbContextOptions);
            repository = new StudentRepository(context);
        }

        public async Task SeedDataAsync(ClassroomDbContext context)
        {
            await Seed.SeedRolesAsync(context);
        }

        [Fact]
        public async Task CanAddStudent()
        {
            var newStudent = new Student();
            newStudent.Name = "new student";

            await repository.AddAsync(newStudent);

            var count = context.Students.Count();
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanReadStudents()
        {
            await SeedDataAsync(context);

            var project = await repository.ReadAsync(Guid.Parse("746bce91-98ba-424d-9451-a585fe2c552b"));

            Assert.Equal("Student", project.Name);
        }

        [Fact]
        public async Task CanReadAllStudents()
        {
            await SeedDataAsync(context);

            var count = repository.ReadAll().Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanUpdateStudent()
        {
            await SeedDataAsync(context);

            var student = await context.Students.SingleOrDefaultAsync(x => x.Id == Guid.Parse("746bce91-98ba-424d-9451-a585fe2c552b"));

            student.Name = "name changed";
            context.Entry(student).State = EntityState.Detached;

            await repository.UpdateAsync(student);

            var count = await context.Students.CountAsync(x => x.Name == "name changed");
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanDeleteStudent()
        {
            await SeedDataAsync(context);

            await repository.DeleteAsync(Guid.Parse("746bce91-98ba-424d-9451-a585fe2c552b"));

            Assert.Equal(0, context.Students.Count());
        }
    }
}
