using API.AuthenticationService;
using DataAccessLayer.Dtos.AuthenticationDTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        public IActionResult Autenticate(AuthenticationRequest request)
        {
            var responce = _userService.Authenticate(request);
            if (responce == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok();
        }
    }
}
