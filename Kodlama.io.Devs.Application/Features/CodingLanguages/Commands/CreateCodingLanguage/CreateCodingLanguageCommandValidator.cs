using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.CreateCodingLanguage
{
    public class CreateCodingLanguageCommandValidator : AbstractValidator<CreateCodingLanguageCommand>
    {
        public CreateCodingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
