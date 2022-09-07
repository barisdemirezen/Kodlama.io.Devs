using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.DeleteCodingLanguage
{
    public class DeleteCodingLanguageCommandValidator : AbstractValidator<DeleteCodingLanguageCommand>
    {
        public DeleteCodingLanguageCommandValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
        }
    }
}
