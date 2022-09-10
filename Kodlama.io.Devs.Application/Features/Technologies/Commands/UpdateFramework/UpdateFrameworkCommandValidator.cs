using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateFramework
{
    public class UpdateFrameworkCommandValidator : AbstractValidator<UpdateFrameworkCommand>
    {
        public UpdateFrameworkCommandValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.CodingLanguageId).NotEmpty();
        }
    }
}
