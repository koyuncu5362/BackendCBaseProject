using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class _Validator : AbstractValidator<_>
    {
        public _Validator()
        {
            RuleFor(_ => _.ProductName).NotEmpty();
            RuleFor(_ => _.ProductName).MinimumLength(2);
            RuleFor(_ => _.UnitPrice).NotEmpty();
            RuleFor(_ => _.UnitPrice).GreaterThan(0);
            //For Special Rules. It says if this is drink it should be greater than 10 for this unitprice
            RuleFor(_ => _.UnitPrice).GreaterThanOrEqualTo(10).When(_ => _.CategoryId == 1);
        }
    }
}
