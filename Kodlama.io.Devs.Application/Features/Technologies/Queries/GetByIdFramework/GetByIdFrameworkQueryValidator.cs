using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdFramework
{
    public class GetByIdFrameworkQueryValidator : AbstractValidator<GetByIdFrameworkQuery>
    {
        public GetByIdFrameworkQueryValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
        }
    }
}
