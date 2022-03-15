using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Mappers;
using DataAccessLayer.Repositories.AssignmentRepositories;
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
    public class AssignmentRepositoryTests : IDisposable
    {
        private readonly DbContextOptions<ClassroomDbContext> dbContextOptions;
        private readonly ClassroomDbContext context;
        private readonly IMapper _mapper;
        private readonly AssignmentRepository repository;

        public async void Dispose()
        {
            await context.Database.EnsureDeletedAsync();
        }

        public AssignmentRepositoryTests()
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
            repository = new AssignmentRepository(context);
        }

        public async Task SeedDataAsync(ClassroomDbContext context)
        {
            await Seed.SeedRolesAsync(context);
        }

        [Fact]
        public async Task CanAddAssignment()
        {
            var newAssignment = new Assignment();
            newAssignment.Name = "new role";

            await repository.AddAsync(newAssignment);

            var count = context.Assignments.Count();
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanReadAssignment()
        {
            await SeedDataAsync(context);

            var project = await repository.ReadAsync(Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"));

            Assert.Equal("Assignment", project.Name);
        }

        [Fact]
        public async Task CanReadAllAssignment()
        {
            await SeedDataAsync(context);

            var count = repository.ReadAll().Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanUpdateAssignment()
        {
            await SeedDataAsync(context);

            var assignment = await context.Assignments.SingleOrDefaultAsync(x => x.Id == Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"));

            assignment.Name = "name changed";
            context.Entry(assignment).State = EntityState.Detached;

            await repository.UpdateAsync(assignment);

            var count = await context.Assignments.CountAsync(x => x.Name == "name changed");
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanDeleteAssignment()
        {
            await SeedDataAsync(context);

            await repository.DeleteAsync(Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"));

            Assert.Equal(0, context.Roles.Count());
        }
    }
}
