using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Mappers;
using DataAccessLayer.Repositories.MessageRepositories;
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
    public class MessageRepositoryTests
    {
        private readonly DbContextOptions<ClassroomDbContext> dbContextOptions;
        private readonly ClassroomDbContext context;
        private readonly IMapper _mapper;
        private readonly MessageRepository repository;

        public async void Dispose()
        {
            await context.Database.EnsureDeletedAsync();
        }

        public MessageRepositoryTests()
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
            repository = new MessageRepository(context);
        }

        public async Task SeedDataAsync(ClassroomDbContext context)
        {
            await Seed.SeedRolesAsync(context);
        }

        [Fact]
        public async Task CanAddMessage()
        {
            var newMessage = new Message();
            //newMessage.Name = "new course";

            await repository.AddAsync(newMessage);

            var count = context.Messages.Count();
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanReadMessage()
        {
            await SeedDataAsync(context);

            var project = await repository.ReadAsync(Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"));

            //Assert.Equal("Course", project.Name);
        }

        [Fact]
        public async Task CanReadAllMessages()
        {
            await SeedDataAsync(context);

            var count = repository.ReadAll().Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanUpdateMessages()
        {
            await SeedDataAsync(context);

            var message = await context.Messages.SingleOrDefaultAsync(x => x.Id == Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"));

            //message.Name = "name changed";
            context.Entry(message).State = EntityState.Detached;

            await repository.UpdateAsync(message);

            var count = await context.Courses.CountAsync(x => x.Name == "name changed");
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CanDeleteMessage()
        {
            await SeedDataAsync(context);

            await repository.DeleteAsync(Guid.Parse("f61ae49b-25c1-4e93-add1-4d9787209185"));

            Assert.Equal(0, context.Messages.Count());
        }
    }
}
