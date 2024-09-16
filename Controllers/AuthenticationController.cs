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
        public async Task<IActionResult> login([FromBody] User user)
        {
            IActionResult response = Unauthorized();
            var authuser = await _authservice.Authenticate(user);
            if (authuser != null)
            {
                var tokenString =  _authservice.GenerateJWT(authuser);
                response = Ok(new {tokenString});
            }
            return Ok(response);
        }

    }
}