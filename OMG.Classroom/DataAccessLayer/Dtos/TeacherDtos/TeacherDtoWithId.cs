using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.TeacherDtos
{
    public class TeacherDtoWithId
    {
        public Guid Id { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public Guid RoleId { get; set; }
    }
}
