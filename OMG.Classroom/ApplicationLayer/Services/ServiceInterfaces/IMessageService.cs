using DataAccessLayer.Dtos.MessageDtos;

namespace ApplicationLayer.Services
{
    public interface IMessageService
    {
        Task AddAsync(MessageDto messageDto);
        Task DeleteAsync(Guid id);
        Task<List<MessageDtoWithId>> ReadAllAsync();
        Task<MessageDtoWithId> ReadAsync(Guid id);
        Task UpdateAsync(MessageDtoWithId messageDto);
    }
}