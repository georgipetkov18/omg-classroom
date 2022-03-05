using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.StudentDtos
{
    public class StudentDtoWithId
    {
        public Guid Id { get; set; }
        public DateTime? DeletedOn { get; set; }
        public Guid RoleId { get; set; }
    }
}
