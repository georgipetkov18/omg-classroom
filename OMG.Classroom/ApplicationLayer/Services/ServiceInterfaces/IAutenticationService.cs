using DataAccessLayer.Dtos.AuthenticationDTOs;

namespace ApplicationLayer.Services
{
    public interface IAutenticationService
    {
        UserDTO SearchUsers(AuthenticationRequest request);
        Task<UserDTO> FindUser(Guid id);
    }
}