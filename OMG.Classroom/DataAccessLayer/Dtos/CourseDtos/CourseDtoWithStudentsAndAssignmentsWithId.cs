using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.CourseDtos
{
    public class CourseDtoWithStudentsAndAssignmentsWithId
    {
        public Guid Id { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Name { get; set; }
        public Guid TeacherId { get; set; }
        public ICollection<User> Students { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
