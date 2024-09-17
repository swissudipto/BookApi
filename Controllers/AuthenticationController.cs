using BookApi.Interfaces;
using BookApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthservice _authservice;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthservice authservice)
        {
            _logger = logger;
            _authservice = authservice;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] User user)
        {
            IActionResult response = Unauthorized();
            var authuser = await _authservice.Authenticate(user);
            if (authuser != null)
            {
                var tokenString =  _authservice.GenerateJWT(authuser);
                response = Ok(new { Token = tokenString});
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            IActionResult response = Unauthorized();
            var newUser = await _authservice.CreateNewUser(user);
            if(newUser != null)
            {
                return Ok(newUser);
            }
            return response;
        }
    }
}