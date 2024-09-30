using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsk.Application.DTOs.Authentication;
using Tsk.Application.Helpers.ResponseHandler;

namespace Tsk.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Respons<AuthDto>> RegisterAsync(RegisterDto model);
        Task<Respons<AuthDto>> GetTokenAsync(TokenRequestDto model);
    }
}
