using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UAWalks.API.Model.DTO;
using UAWalks.API.Repository;

namespace UAWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegistration registration;
        private readonly ILog loging;

        public AuthController(IRegistration registration,ILog loging)
        {
            this.registration = registration;
            this.loging = loging;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RequestRegDto request)
        {
            var result = await registration.RegisterAsync(request);
            if (result != null)
            {
                if (result.Succeeded) return Ok("User registered successfully");
            }
            return BadRequest("User registration failed.");
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] RequestLoginDto request)
        {
            var Login = await loging.Loging(request);
            if (Login != null)
            {
                var response = new LoginResponseDto { JwtToken = Login };
                return Ok(response);
            }

            return Unauthorized("Invalid username or password");
        }
    }
}
