using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Teacher : User
    {
        public Guid RoleId { get; set; }

        public Role Role { get; set; }
    }
}
