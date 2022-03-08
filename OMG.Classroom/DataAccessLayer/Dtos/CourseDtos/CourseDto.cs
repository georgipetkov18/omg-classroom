using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.CourseDtos
{
    public class CourseDto
    {
        public DateTime? DeletedOn { get; set; }
        public string Name { get; set; }
        public Guid TeacherId { get; set; }
    }
}
