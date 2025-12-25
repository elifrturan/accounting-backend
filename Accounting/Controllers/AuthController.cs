using Accounting.Application.DTOs;
using Accounting.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            await _authService.RegisterAsync(request);
            return Ok(new
            {
                message = "Kayıt işlemi başarıyla tamamlandı"
            });
        }
    }
}
