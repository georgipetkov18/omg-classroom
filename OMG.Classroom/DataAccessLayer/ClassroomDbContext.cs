using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClassroomDbContext : DbContext
    {
        public ClassroomDbContext(DbContextOptions<ClassroomDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-E57GMEU\SQLEXPRESS;Database=OMGClassroom;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");

            //Implements Soft Delete filter
            modelBuilder.Entity<Assignment>().HasQueryFilter(x => x.DeletedOn != null);
            modelBuilder.Entity<Course>().HasQueryFilter(x => x.DeletedOn != null);
            modelBuilder.Entity<Message>().HasQueryFilter(x => x.DeletedOn != null);
            modelBuilder.Entity<Role>().HasQueryFilter(x => x.DeletedOn != null);
            modelBuilder.Entity<User>().HasQueryFilter(x => x.DeletedOn != null);
            

            modelBuilder.Entity<Assignment>()
                .HasOne<Student>(s => s.Student)
                .WithMany(a => a.Assignments)
                .HasForeignKey(u => u.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses);
        }

        //Overriden SaveChanges methods to suppress hard delete in favor of soft delete
        public override int SaveChanges()
        {
            HandleDeletedEntities();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleDeletedEntities();
            return base.SaveChangesAsync(cancellationToken);
        }
        
        private void HandleDeletedEntities()
        {
            //Takes the to be deleted entities and instead updates them with the correct time
            var toBeDeleted = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted);
            foreach (var item in toBeDeleted)
            {
                BaseEntity entity = item.Entity as BaseEntity;
                entity.DeletedOn = DateTime.Now;
                item.State = EntityState.Modified;
            }
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
