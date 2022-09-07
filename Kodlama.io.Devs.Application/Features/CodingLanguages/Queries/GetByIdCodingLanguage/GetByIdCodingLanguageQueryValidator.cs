using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.CodingLanguages.Queries.GetByIdCodingLanguage
{
    public class GetByIdCodingLanguageQueryValidator : AbstractValidator<GetByIdCodingLanguageQuery>
    {
        public GetByIdCodingLanguageQueryValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
        }
    }
}
