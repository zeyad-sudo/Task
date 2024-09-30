using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsk.Application.DTOs.CarDto;
using Tsk.Application.Helpers.ResponseHandler;
using Tsk.Application.Interfaces;
using Tsk.Data.Entities;
using Tsk.Infrastructure.Repositories.UnitOfWork;

namespace Tsk.Application.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Respons<string>> AddCarAsync(AddCarDto model)
        {
            await _unitOfWork.cars.AddAsync(new Car
            {
                Color = model.Color,
                Model = model.Model,
                ManufacturerYear = model.ManufacturerYear,
                Brand = model.Brand
            });
            return ResponseHandler.Created("Car added successfully");
        }

        public async Task<Respons<string>> DeleteCarAsync(int carId)
        {
            var car = await _unitOfWork.cars.GetByIdAsync(carId);
            if (car == null) return ResponseHandler.NotFound<string>("Car not found");
            await _unitOfWork.cars.DeleteAsync(car);
            return ResponseHandler.Deleted<string>();

        }
        public async Task<Respons<IEnumerable<Car>>> GetAllCarsAsync()
        {
            var cars = await _unitOfWork.cars.GetAllAsync();
            return ResponseHandler.Success(cars);
        }

        public async Task<Respons<CarDto>> GetCarByIdAsync(int carId)
        {
            var car = await _unitOfWork.cars.GetByExpressionSingleAsync(x => x.PlateNumber == carId /*,[x => x.ApplicationUser]*/);
            if (car == null) return ResponseHandler.NotFound<CarDto>("Car not found");
            return ResponseHandler.Success(new CarDto
            {
                PlateNumber = car.PlateNumber,
                Color = car.Color,
                Model = car.Model,
                ManufacturerYear = car.ManufacturerYear,
                Brand = car.Brand,
            });
        }

        

        public async Task<Respons<string>> UpdateCarAsync(UpdateCarDto model)
        {
            var car = await _unitOfWork.cars.GetByExpressionSingleAsync(x => x.PlateNumber == model.PlateNumber);
            if (car == null) return ResponseHandler.NotFound<string>("Car not found");
            car.Color = model.Color;
            car.Model = model.Model;
            car.ManufacturerYear = model.ManufacturerYear;
            car.Brand = model.Brand;
            await _unitOfWork.cars.UpdateAsync(car);
            return ResponseHandler.Updated("Car updated successfully");
        }
    }
}
