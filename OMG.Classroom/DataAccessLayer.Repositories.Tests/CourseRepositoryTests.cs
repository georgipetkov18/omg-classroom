using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Mappers;
using DataAccessLayer.Repositories.CourseRepositories;
using DataAccessLayer.Repositories.RoleRepositories;
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
    public class CourseRepositoryTests
    {
        private readonly DbContextOptions<ClassroomDbContext> dbContextOptions;
        private readonly ClassroomDbContext context;
        private readonly IMapper _mapper;
        private readonly CourseRepository repository;

        public async void Dispose()
        {
            await context.Database.EnsureDeletedAsync();
        }

        public CourseRepositoryTests()
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
            repository = new CourseRepository(context);
        }

        public async Task SeedDataAsync(ClassroomDbContext context)
        {
            await Seed.SeedRolesAsync(context);
            await Seed.SeedTeachersAsync(context);
            await Seed.SeedStudentsAsync(context);
            await Seed.SeedCoursesAsync(context);
            await Seed.SeedAssignmentsAsync(context);
            await Seed.SeedMessagesAsync(context);
        }

        [Fact]
        public async Task CanAddCourse()
        {
            var newCourse = new Course();
            newCourse.Name = "new course";

            await repository.AddAsync(newCourse);

            var count = context.Courses.Count();
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanReadCourse()
        {
            await SeedDataAsync(context);

            var project = await repository.ReadAsync(Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"));

            Assert.Equal("Course", project.Name);
        }

        [Fact]
        public async Task CanReadAllCourses()
        {
            await SeedDataAsync(context);

            var count = repository.ReadAll().Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanUpdateCourse()
        {
            await SeedDataAsync(context);

            var course = await context.Courses.SingleOrDefaultAsync(x => x.Id == Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"));

            course.Name = "name changed";
            context.Entry(course).State = EntityState.Detached;

            await repository.UpdateAsync(course);

            var count = await context.Courses.CountAsync(x => x.Name == "name changed");
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanDeleteCourse()
        {
            await SeedDataAsync(context);

            await repository.DeleteAsync(Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"));

            Assert.Equal(0, context.Courses.Count());
        }
    }
}
