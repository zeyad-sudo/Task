using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tsk.Application.DTOs.Authentication;
using Tsk.Application.Interfaces;
using Tsk.Application.Helpers.ResponseHandler;

namespace Tsk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.RegisterAsync(model);
            return this.CreateResponse(result);
        }
        [HttpPost("LogIn")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.GetTokenAsync(model);
            return this.CreateResponse(result);
        }

    }
}
