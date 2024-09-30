using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsk.Application.DTOs.UserCarDto;
using Tsk.Application.Helpers.ResponseHandler;
using Tsk.Application.Interfaces;
using Tsk.Data.Entities;
using Tsk.Infrastructure.Repositories.UnitOfWork;

namespace Tsk.Application.Services
{
    public class UserCarService : IUserCarService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserCarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Respons<string>> AssignCarToUserAsync(AssignCarToUserDto model)
        {
            var user = await _unitOfWork.users.GetByExpressionSingleAsync(x => x.Id == model.ApplicationUserId);
            if (user == null) return ResponseHandler.NotFound<string>("user not found");
            var car = await _unitOfWork.cars.GetByExpressionSingleAsync(x => x.PlateNumber == model.CarBlateNumber);
            if (car == null) return ResponseHandler.NotFound<string>("Car not found");
            var userCar = new UserCar
            {
                ApplicationUserID = model.ApplicationUserId,
                CarPlateNumber = model.CarBlateNumber,
                AssignDate = model.AssignedDate,
                LastMeterReading = model.LastMeterReading
            };
            
            await _unitOfWork.userCars.UpdateAsync(userCar);
            return ResponseHandler.Updated("Car assigned successfully");
        }

        public async Task<Respons<string>> EditCarAssignmentAsync(EditCarAssignmentDto model)
        {
            var userCar = await _unitOfWork.userCars.GetByExpressionSingleAsync(x => x.Id == model.Id);
            if (userCar == null) return ResponseHandler.NotFound<string>("Car assignment not found");
            userCar.ApplicationUserID = model.ApplicationUserID;
            userCar.CarPlateNumber = model.CarPlateNumber;
            userCar.AssignDate = model.AssignedDate;
            userCar.LastMeterReading = model.LastMeterReading;
            await _unitOfWork.userCars.UpdateAsync(userCar);
            return ResponseHandler.Updated("Car assignment updated successfully");
        }

        public async Task<Respons<string>> UnassignCarFromUserAsync(int UserCarId)
        {
            var usercar = await _unitOfWork.userCars.GetByExpressionSingleAsync(x =>x.Id==UserCarId);
            if (usercar == null) return ResponseHandler.NotFound<string>("there is no car assigned  to any user with this id found");
            await _unitOfWork.userCars.DeleteAsync(usercar);
            return ResponseHandler.Updated("Car unassigned successfully");
        }
    }
}
