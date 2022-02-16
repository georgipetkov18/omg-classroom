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
        [MaxLength(255)]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid AssignmentId { get; set; }
        public User Author { get; set; }
        
        
        public Assignment Assignment { get; set; }
    }
}
