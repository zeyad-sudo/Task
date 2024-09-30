using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsk.Application.DTOs.ApplicatiionUserDto;
using Tsk.Application.Helpers.ResponseHandler;
using Tsk.Application.Interfaces;
using Tsk.Data.Entities;
using Tsk.Infrastructure.Repositories.UnitOfWork;

namespace Tsk.Application.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<Respons<string>> CreateUserAsync(UserDto model)
        {
            if (model == null) return ResponseHandler.BadRequest<string>("model is null");
            var user = new ApplicationUser
            {
                PhoneNumber = model.phoneNumber,
                IdentityNumber = model.IdentitNumber
            };
            await _userManager.CreateAsync(user);
            return ResponseHandler.Created("User created successfully");
        }

        public async Task<Respons<string>> DeleteUserAsync(string ID)
        {
            var user = await _userManager.FindByIdAsync(ID);
            if (user == null) return ResponseHandler.NotFound<string>("User not found");
            await _userManager.DeleteAsync(user);
            return ResponseHandler.Deleted<string>();
        }

        public async Task<Respons<UserDto>> GetUserByIDAsync(string ID)
        {
            var user = await _userManager.FindByIdAsync(ID);
            if (user == null) return ResponseHandler.NotFound<UserDto>("User not found");
            var userDto = new UserDto
            {
                IdentitNumber = user.IdentityNumber,
                phoneNumber = user.PhoneNumber
            };
            return ResponseHandler.Success(userDto);
        }

       

        public async Task<Respons<string>> UpdateUserAsync(UserDto model)
        {
            var user = await _userManager.FindByIdAsync(model.IdentitNumber);
            if (user == null) return ResponseHandler.NotFound<string>("User not found");
            user.PhoneNumber = model.phoneNumber;
            user.IdentityNumber = model.IdentitNumber;
            await _userManager.UpdateAsync(user);
            return ResponseHandler.Updated("User updated successfully");
        }
    }
}
