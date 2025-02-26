using Euronet.System;
using Euronet.System.Helpers;
using Microsoft.AspNetCore.Mvc;
using Euronet.System.Settings;

namespace DccMeter.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelper _jwtHelper;

        public AuthController(JwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Validate user credentials (usually you would check this against a database)
            if (model.Username == Settings.Instance.JwtSettings.SecretKey && model.Password == Settings.Instance.JwtSettings.Password)
            {
                var token = await _jwtHelper.GenerateJwtTokenAsync(model.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }

       
    }
}
