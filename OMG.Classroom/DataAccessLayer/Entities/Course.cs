using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<User> Students { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
