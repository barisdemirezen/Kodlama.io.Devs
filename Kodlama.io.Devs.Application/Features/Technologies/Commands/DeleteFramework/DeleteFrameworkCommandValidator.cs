using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteFramework
{
    public class DeleteFrameworkCommandValidator : AbstractValidator<DeleteFrameworkCommand>
    {
        public DeleteFrameworkCommandValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
        }
    }
}
