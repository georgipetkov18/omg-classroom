using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.StudentDtos
{
    public class StudentDtoWithAssignments
    {
        public DateTime? DeletedOn { get; set; }
        public Guid RoleId { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
