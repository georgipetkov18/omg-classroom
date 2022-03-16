using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Dtos.MessageDtos;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.MessageRepositories;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task AddAsync(MessageDto messageDto)
        {
            await _messageRepository.AddAsync(messageDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _messageRepository.DeleteAsync(id);
        }

        public async Task<List<MessageDto>> ReadAllAssync()
        {
            return await _messageRepository.ReadAll().ToListAsync();
        }

        public async Task<MessageDtoWithId> ReadAsync(Guid id)
        {
            return await _messageRepository.ReadAsync(id);
        }

        public async Task UpdateAsync(MessageDtoWithId messageDto)
        {
            await _messageRepository.UpdateAsync(messageDto);
        }
    }
}
