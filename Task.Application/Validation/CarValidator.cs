
using FluentValidation;
using Tsk.Data.Entities;

namespace Tsk.Application.Validation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {   
            RuleFor(x => x.Color).NotEmpty().WithMessage("Color is required");
            RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required");
            RuleFor(x => x.ManufacturerYear).NotEmpty().WithMessage("ManufacturerYear is required");
            RuleFor(x => x.Brand).NotEmpty().WithMessage("Brand is required");
        }
    }
}
