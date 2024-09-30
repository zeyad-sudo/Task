using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tsk.Application.DTOs.Authentication;
using Tsk.Application.Helpers.JWT;
using Tsk.Application.Helpers.ResponseHandler;
using Tsk.Application.Interfaces;
using Tsk.Data.Entities;
using Tsk.Infrastructure.Repositories.UnitOfWork;

namespace Tsk.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtHelper _jwt;

        public AuthService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JwtHelper> jwt)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _jwt = jwt.Value;
            _roleManager = roleManager;
        }
        public async Task<Respons<AuthDto>> GetTokenAsync(TokenRequestDto model)
        {
            var authmodel = new AuthDto();
            var user=await _unitOfWork.users.GetByExpressionSingleAsync(x=>x.IdentityNumber == model.IdentityNumber);
            if (user is null || (!await _userManager.CheckPasswordAsync(user, model.Password)))
            {
                return ResponseHandler.BadRequest<AuthDto>("Email or pass is incorrect");
            }
            var JwtSecurityToken = await CreateJwtToken(user);
            authmodel.IdentityNumber = user.IdentityNumber;
            authmodel.Email = user.Email;
            authmodel.Name = user.FullName;
            authmodel.PhoneNumber = user.PhoneNumber;
            authmodel.Age = user.Age;
            authmodel.ExpiresOn = JwtSecurityToken.ValidTo;
            authmodel.Token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken);

            var roleslist = await _userManager.GetRolesAsync(user);
            authmodel.Roles = roleslist.ToList();
            return ResponseHandler.Success(authmodel);
        }

        public async Task<Respons<AuthDto>> RegisterAsync(RegisterDto model)
        {
            var user1 = await _unitOfWork.users.GetByExpressionSingleAsync(x => x.IdentityNumber == model.IdentityNumber);
            if (user1 is not null)
            {
                if (await _userManager.FindByEmailAsync(model.Email) is not null)
                    return ResponseHandler.BadRequest<AuthDto>("email is already Register");
                if (await _userManager.FindByNameAsync(model.IdentityNumber) is not null)
                    return ResponseHandler.BadRequest<AuthDto>("UserName is already Register");
            }
           


            var user = new ApplicationUser
            {
                IdentityNumber = model.IdentityNumber,
                Email = model.Email,
                FullName = model.Name,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                UserName = model.IdentityNumber
            };

            var result = user1 == null ?
                await _userManager.CreateAsync(user, model.Password) : await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description}, ";
                }
                return ResponseHandler.BadRequest<AuthDto>(errors);
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var rs = await _userManager.ResetPasswordAsync(user, token, model.Password);
            if (!rs.Succeeded)
            {
                var errorMessage = string.Join(", ", rs.Errors.Select(error => error.Description));
                return ResponseHandler.BadRequest<AuthDto>(errorMessage);
            }

            await _userManager.AddToRoleAsync(user, "User");
            var JwtSecurityToken = await CreateJwtToken(user);
            var authdto = new AuthDto
            {
                IdentityNumber = user.IdentityNumber,
                Email = user.Email,
                Name = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Age = user.Age,
                ExpiresOn = JwtSecurityToken.ValidTo,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken),
            };
            return ResponseHandler.Created(authdto);
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
