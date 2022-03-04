using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Message : BaseEntity
    {
        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid AssignmentId { get; set; }
        public User Author { get; set; }
        //added >>
        public Guid AuthorId { get; set; }
        
        
        public Assignment Assignment { get; set; }
    }
}
