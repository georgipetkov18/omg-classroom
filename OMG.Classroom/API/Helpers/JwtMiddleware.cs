using API.AuthenticationService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace API.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly AppSettings _appSettings;       

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> options)
        {
            _requestDelegate = next;
            _appSettings = options.Value;           
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Autorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
               await attachUserToContext(context, userService, token);
            }
        }

        private async Task attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwt = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwt.Claims.First(x => x.Type == "id").Value);
                context.Items["Users"] = await userService.GetById(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
