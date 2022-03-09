using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.MessagesRepositories
{
     public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(ClassroomDbContext context) : base(context)
        {

        }
    }

}
