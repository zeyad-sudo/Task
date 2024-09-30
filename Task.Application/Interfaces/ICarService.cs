using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsk.Application.DTOs.CarDto;
using Tsk.Application.Helpers.ResponseHandler;
using Tsk.Data.Entities;

namespace Tsk.Application.Interfaces
{
    public interface ICarService
    {
        Task<Respons<CarDto>> GetCarByIdAsync(int carId);
        Task<Respons<IEnumerable<Car>>> GetAllCarsAsync();
        Task<Respons<string>> AddCarAsync(AddCarDto model);
        Task<Respons<string>> UpdateCarAsync(UpdateCarDto model);
        Task<Respons<string>> DeleteCarAsync(int carId);
    }
}
