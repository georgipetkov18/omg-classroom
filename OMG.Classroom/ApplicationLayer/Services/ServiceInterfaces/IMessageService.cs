using DataAccessLayer.Dtos.MessageDtos;

namespace ApplicationLayer.Services
{
    public interface IMessageService
    {
        Task AddAsync(MessageDto messageDto);
        Task DeleteAsync(Guid id);
        Task<List<MessageDto>> ReadAllAssync();
        Task<MessageDtoWithId> ReadAsync(Guid id);
        Task UpdateAsync(MessageDtoWithId messageDto);
    }
}