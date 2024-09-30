using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsk.Application.DTOs.ApplicatiionUserDto;
using Tsk.Application.Helpers.ResponseHandler;
using Tsk.Data.Entities;

namespace Tsk.Application.Interfaces
{
    public interface IApplicationUserService
    {
        Task<Respons<UserDto>> GetUserByIDAsync(string ID);
        Task<Respons<string>> DeleteUserAsync(string ID);
        Task<Respons<string>> UpdateUserAsync(UserDto model);
        Task<Respons<string>> CreateUserAsync(UserDto model);
    }
}
