using BL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Validators
{
    public class StoreConfigurationValidator : AbstractValidator<StoreConfiguration>
    {
        public StoreConfigurationValidator(StoreConfiguration configuration)
        {
            //this.va
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CalculationType.Id).NotEmpty();
            if(configuration.CalculationType.Id == 1)
            {
                RuleFor(x => x.PointsAmt).NotEmpty().GreaterThan(0); 
                RuleFor(x => x.PerPurchaseAmt).NotEmpty().GreaterThan(0);
            }
            RuleFor(x => x.StoreId).NotEmpty().GreaterThan(0);
        }

    }

    public class UpdateStoreConfigurationValidator : AbstractValidator<StoreConfiguration>
    {
        public UpdateStoreConfigurationValidator(StoreConfiguration configuration)
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CalculationType.Id).NotEmpty();
            if (configuration.CalculationType.Id == 1)
            {
                RuleFor(x => x.PointsAmt).NotEmpty().GreaterThan(0);
                RuleFor(x => x.PerPurchaseAmt).NotEmpty().GreaterThan(0);
            }
            RuleFor(x => x.StoreId).NotEmpty().GreaterThan(0);
        }
    }

}
