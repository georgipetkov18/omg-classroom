using API.Helpers;
using ApplicationLayer.Services;
using DataAccessLayer.Dtos.AuthenticationDTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.AuthenticationService
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IAutenticationService _autenticationService;
        public UserService(IOptions<AppSettings> option, IAutenticationService autenticationService)
        {
            _appSettings = option.Value;
            _autenticationService = autenticationService;
        }

        public AuthenticateResponse Authenticate(AuthenticationRequest request)
        {
            var user = _autenticationService.SearchUsers(request);
            if (user == null)
            {
                return null;
            }
            string token = GenerateJWTToken(user);
            return new AuthenticateResponse(user, token);
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            return await _autenticationService.FindUser(id);
        }

        private string GenerateJWTToken(UserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
