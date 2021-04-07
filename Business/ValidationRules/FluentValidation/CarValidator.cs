using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //Dogrulama kuralları:
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description boş gecilemez.");
            RuleFor(c => c.Description).MinimumLength(1).WithMessage("Description minimum 1 karakter olmalıdır.");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("DailPrice 0 dan büyük olmalıdır gecilemez.");
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage("DailPrice boş gecilemez.");

        }
    }   
}
