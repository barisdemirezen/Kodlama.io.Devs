using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateFramework
{
    public class CreateFrameworkCommandValidator : AbstractValidator<CreateFrameworkCommand>
    {
        public CreateFrameworkCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.CodingLanguageId).NotEmpty();
        }
    }
}
