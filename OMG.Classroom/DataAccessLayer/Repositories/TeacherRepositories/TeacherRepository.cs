using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.TeacherRepositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ClassroomDbContext context) : base(context)
        {
        }
    }
}
