using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByCodingLanguageIdFramework
{
    public class GetByCodingLanguageIdFrameworkQueryValidator : AbstractValidator<GetByCodingLanguageIdFrameworkQuery>
    {
        public GetByCodingLanguageIdFrameworkQueryValidator()
        {
            RuleFor(e => e.CodingLanguageId).NotEmpty();
        }
    }
}
