using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Mappers;
using DataAccessLayer.Repositories.TeacherRepositories;
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
    public class TeacherRepositoryTests
    {
        private readonly DbContextOptions<ClassroomDbContext> dbContextOptions;
        private readonly ClassroomDbContext context;
        private readonly IMapper _mapper;
        private readonly TeacherRepository repository;

        public async void Dispose()
        {
            await context.Database.EnsureDeletedAsync();
        }

        public TeacherRepositoryTests()
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
            repository = new TeacherRepository(context);
        }

        public async Task SeedDataAsync(ClassroomDbContext context)
        {
            await Seed.SeedRolesAsync(context);
        }

        [Fact]
        public async Task CanAddTeacher()
        {
            var newTeacher = new Teacher();
            newTeacher.Name = "new teacher";

            await repository.AddAsync(newTeacher);

            var count = context.Teachers.Count();
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanReadTeacher()
        {
            await SeedDataAsync(context);

            var project = await repository.ReadAsync(Guid.Parse("71a7dbfa-6489-4f91-be4e-f9c71c2faafa"));

            Assert.Equal("Teacher", project.Name);
        }

        [Fact]
        public async Task CanReadAllTeachers()
        {
            await SeedDataAsync(context);

            var count = repository.ReadAll().Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanUpdateTeacher()
        {
            await SeedDataAsync(context);

            var teacher = await context.Teachers.SingleOrDefaultAsync(x => x.Id == Guid.Parse("71a7dbfa-6489-4f91-be4e-f9c71c2faafa"));

            teacher.Name = "name changed";
            context.Entry(teacher).State = EntityState.Detached;

            await repository.UpdateAsync(teacher);

            var count = await context.Teachers.CountAsync(x => x.Name == "name changed");
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanDeleteTeacher()
        {
            await SeedDataAsync(context);

            await repository.DeleteAsync(Guid.Parse("71a7dbfa-6489-4f91-be4e-f9c71c2faafa"));

            Assert.Equal(0, context.Teachers.Count());
        }
    }
}
