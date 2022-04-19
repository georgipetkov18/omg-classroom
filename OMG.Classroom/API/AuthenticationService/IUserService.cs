using DataAccessLayer.Dtos.AuthenticationDTOs;

namespace API.AuthenticationService
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticationRequest request);
        Task<UserDTO> GetById(Guid id);
    }
}