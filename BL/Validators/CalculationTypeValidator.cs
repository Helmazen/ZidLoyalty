using BL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Validators
{
    public class CalculationTypeValidator : AbstractValidator<CalculationType>
    {
        public CalculationTypeValidator()
        {
            //this.va
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Desciption).NotEmpty();
            RuleFor(x => x.DesciptionAr).NotEmpty();

        }

    }

    public class UpdateCalculationTypeValidator : AbstractValidator<CalculationType>
    {
        public UpdateCalculationTypeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Desciption).NotEmpty();
            RuleFor(x => x.DesciptionAr).NotEmpty();
        }
    }

}
