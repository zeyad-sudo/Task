using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tsk.Application.DTOs.CarDto;
using Tsk.Application.Helpers.ResponseHandler;
using Tsk.Application.Interfaces;

namespace Tsk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var response = await _carService.GetAllCarsAsync();
            return this.CreateResponse(response);
        }
        [HttpGet("{carId}")]
        public async Task<IActionResult> GetCarById([FromRoute] int carId)
        {
            var response = await _carService.GetCarByIdAsync(carId);
            return this.CreateResponse(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] AddCarDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _carService.AddCarAsync(model);
            return this.CreateResponse(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _carService.UpdateCarAsync(model);
            return this.CreateResponse(response);
        }
        [HttpDelete("{carId}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int carId)
        {
            var response = await _carService.DeleteCarAsync(carId);
            return this.CreateResponse(response);
        }
    }
}
