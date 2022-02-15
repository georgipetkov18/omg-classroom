using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Message : BaseEntity
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid AssignmentId { get; set; }
        public User Author { get; set; }
        
        
        public Assignment Assignment { get; set; }
    }
}
