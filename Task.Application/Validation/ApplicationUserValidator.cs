using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsk.Data.Entities;

namespace Tsk.Application.Validation
{
    public class ApplicationUserValidator: AbstractValidator<ApplicationUser>
    {
        public ApplicationUserValidator()
        {
            RuleFor(x => x.IdentityNumber).NotEmpty().WithMessage("IdentityNumber is required");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required");
        }
    }
}
