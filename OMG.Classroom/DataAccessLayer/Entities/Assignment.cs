using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Assignment : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDone { get; set; }
        public double Grade { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
