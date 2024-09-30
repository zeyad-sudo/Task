using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tsk.Application.Interfaces;
using Tsk.Application.Helpers.ResponseHandler;
using Tsk.Application.DTOs.UserCarDto;
namespace Tsk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCarController : ControllerBase
    {
        private readonly IUserCarService _userCarService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserCarController(IUserCarService userCarService, IHttpContextAccessor httpContextAccessor)
        {
            _userCarService = userCarService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        public async Task<IActionResult> AssignCarToUserAsync([FromBody] AssignCarToUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _userCarService.AssignCarToUserAsync(model);

            return this.CreateResponse(response);
        }
        [HttpDelete("UnassignCar/{UserCarId}")]
        public async Task<IActionResult> UnassignCarFromUserAsync(int UserCarId)
        {
            var response = await _userCarService.UnassignCarFromUserAsync(UserCarId);

            return this.CreateResponse(response);
        }
        [HttpPut]
        public async Task<IActionResult> EditCarAssignmentAsync([FromBody] EditCarAssignmentDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _userCarService.EditCarAssignmentAsync(model);

            return this.CreateResponse(response);
        }
    }
}
