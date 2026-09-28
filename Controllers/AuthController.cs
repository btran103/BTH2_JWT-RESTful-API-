using JwtApi.Data;
using JwtApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace JwtApi.Controllers
{
    [ApiController]
    [Route("")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            var user = UserData.Users.FirstOrDefault(
                u => u.UserName == request.UserName &&
                     u.Password == request.Password
            );

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Sai username hoặc password"
                });
            }

            var token = _jwtService.GenerateToken(user);

            user.Token = token;

            return Ok(new
            {
                message = "Đăng nhập thành công",
                userName = user.UserName,
                token = token
            });
        }

        [HttpGet("auth")]
        [Authorize]
        public IActionResult Auth()
        {
            return Ok(new
            {
                message = "Token hợp lệ",
                user = User.Identity?.Name
            });
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; } = "";

        public string Password { get; set; } = "";
    }
}