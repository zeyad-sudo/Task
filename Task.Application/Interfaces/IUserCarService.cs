using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsk.Application.DTOs.UserCarDto;
using Tsk.Application.Helpers.ResponseHandler;

namespace Tsk.Application.Interfaces
{
    public interface IUserCarService
    {
        Task<Respons<string>> AssignCarToUserAsync(AssignCarToUserDto model);
        Task<Respons<string>> UnassignCarFromUserAsync(int UserCarId);
        Task<Respons<string>> EditCarAssignmentAsync(EditCarAssignmentDto model);
    }
}
