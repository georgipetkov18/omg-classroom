using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.CourseRepositories
{
    public class CourseRepository : ICourseRepository
    {
        public readonly ClassroomDbContext classroomDbContext;

        public CourseRepository(ClassroomDbContext classroomDbContext)
        {
            this.classroomDbContext = classroomDbContext;
        }
        public void Add(Course course)
        {
            classroomDbContext.Courses.Add(course);
            classroomDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Course course = classroomDbContext.Courses.Find(id);
            if (course == null)
            {
                throw new ArgumentNullException();
            }
            classroomDbContext.Courses.Remove(course);
            classroomDbContext.SaveChanges();
        }

        public IQueryable<Course> ReadAll()
        {
            return classroomDbContext.Courses.AsQueryable();
        }

        public Course Read(Guid id)
        {
            Course course = classroomDbContext.Courses.Find(id);
            if (course == null)
            {
                throw new ArgumentNullException();
            }
            return course;
        }

        public void Update(Course course)
        {
            classroomDbContext.Courses.Update(course);
            classroomDbContext.SaveChanges();
        }
    }
}
