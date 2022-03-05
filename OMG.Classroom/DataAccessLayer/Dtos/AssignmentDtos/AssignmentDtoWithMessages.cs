using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.AssignmentDtos
{
    public class AssignmentDtoWithMessages
    {
        public DateTime? DeletedOn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDone { get; set; }
        public double Grade { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
