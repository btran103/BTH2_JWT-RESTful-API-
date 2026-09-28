using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class HelloController : ControllerBase
    {
        [HttpGet("hello")]
        [Authorize]
        public IActionResult Hello()
        {
            return Ok("Hello World");
        }
    }
}