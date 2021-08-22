using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MaximumLength(3);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(500000).When(c => c.CarId == 2);
            //RuleFor(c => c.CarName).Must(StartWithB).WithMessage(" Carname must start with B ");
        }

        //private bool StartWithB(string arg)
        //{
        //    return arg.StartsWith("B");
        //}
    }
}
