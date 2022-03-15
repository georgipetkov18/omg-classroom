using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Mappers;
using DataAccessLayer.Repositories.RoleRepositories;
using DataAccessLayer.Seeder;
using Xunit;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Tests
{
    public class RoleRepositoryTests : IDisposable
    {
        private readonly DbContextOptions<ClassroomDbContext> dbContextOptions;
        private readonly ClassroomDbContext context;
        private readonly IMapper _mapper;
        private readonly RoleRepository repository;

        public async void Dispose()
        {
            await context.Database.EnsureDeletedAsync();
        }

        public RoleRepositoryTests()
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
            repository = new RoleRepository(context);
        }

        public async Task SeedDataAsync(ClassroomDbContext context)
        {
            await Seed.SeedRolesAsync(context);
        }

        [Fact]
        public async Task CanAddRole()
        {
            var newRole = new Role();
            newRole.Name = "new role";

            await repository.AddAsync(newRole);

            var count = context.Roles.Count();
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanReadRole()
        {
            await SeedDataAsync(context);

            var project = await repository.ReadAsync(Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"));

            Assert.Equal("Director", project.Name);
        }

        [Fact]
        public async Task CanReadAllRoles()
        {
            await SeedDataAsync(context);

            var count = repository.ReadAll().Count();

            Assert.Equal(4, count);
        }

        [Fact]
        public async Task CanUpdateRole()
        {
            await SeedDataAsync(context);

            var role = await context.Roles.SingleOrDefaultAsync(x => x.Id == Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"));

            role.Name = "name changed";
            context.Entry(role).State = EntityState.Detached;

            await repository.UpdateAsync(role);

            var count = await context.Roles.CountAsync(x => x.Name == "name changed");
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanDeleteRole()
        {
            await SeedDataAsync(context);

            await repository.DeleteAsync(Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"));

            Assert.Equal(3, context.Roles.Count());
        }

    }
}
