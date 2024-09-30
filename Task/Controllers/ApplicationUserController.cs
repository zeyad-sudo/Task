using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tsk.Application.DTOs.ApplicatiionUserDto;
using Tsk.Application.Helpers.ResponseHandler;
using Tsk.Application.Interfaces;
using Tsk.Application.Services;
using Tsk.Data.Entities;

namespace Tsk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserService _applicationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUserController(IApplicationUserService applicationService, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _applicationService = applicationService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("{ID}")]
        public async Task<IActionResult> GetSingleUserAsync([FromRoute] string ID)
        {
            var response = await _applicationService.GetUserByIDAsync(ID);

            return this.CreateResponse(response);
        }
        [HttpDelete("DeleteUser/{ID}")]
        public async Task<IActionResult> DeleteSingleAsync(string ID)
        {
            var response = await _applicationService.DeleteUserAsync(ID);

            return this.CreateResponse(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _applicationService.CreateUserAsync(model);

            return this.CreateResponse(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _applicationService.UpdateUserAsync(model);

            return this.CreateResponse(response);
        }
    }
}
