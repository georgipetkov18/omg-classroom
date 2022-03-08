using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.StudentDtos
{
    public class StudentDtoWithCollectionsWithId
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public Guid Id { get; set; }
        public DateTime? DeletedOn { get; set; }
        public Guid RoleId { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
