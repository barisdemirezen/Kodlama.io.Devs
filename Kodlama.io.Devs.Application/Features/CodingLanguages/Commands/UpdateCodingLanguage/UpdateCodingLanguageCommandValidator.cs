using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.UpdateCodingLanguage
{
    public class UpdateCodingLanguageCommandValidator : AbstractValidator<UpdateCodingLanguageCommand>
    {
        public UpdateCodingLanguageCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
        }
    }
}
