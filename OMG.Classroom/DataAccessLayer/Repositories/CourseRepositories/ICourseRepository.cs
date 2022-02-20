using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.CourseRepositories
{
    public interface ICourseRepository
    {
        void Add(Course course);
        Course Read(Guid id);
        IQueryable<Course> ReadAll();
        void Delete(Guid id);
        void Update(Course course);
    }
}
