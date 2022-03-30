using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.MessageDtos
{
    public class MessageDtoWithId
    {
        public Guid Id { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid AssignmentId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
