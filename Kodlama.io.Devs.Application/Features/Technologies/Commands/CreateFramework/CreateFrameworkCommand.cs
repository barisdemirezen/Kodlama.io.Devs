using AutoMapper;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateFramework
{
    public class CreateFrameworkCommand : IRequest<CreatedFrameworkDto>
    {
        public string Name { get; set; }
        public int CodingLanguageId { get; set; }

        public class CreatedFrameworkCommandHandler : IRequestHandler<CreateFrameworkCommand, CreatedFrameworkDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly FrameworkBusinessRules _frameworkBusinessRules;

            public CreatedFrameworkCommandHandler(IMapper mapper, IFrameworkRepository frameworkRepository, FrameworkBusinessRules frameworkBusinessRules)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
                _frameworkBusinessRules = frameworkBusinessRules;
            }

            public async Task<CreatedFrameworkDto> Handle(CreateFrameworkCommand request, CancellationToken cancellationToken)
            {
                await _frameworkBusinessRules.FrameworkNameCannotBeRepeatedWhenInsertedAsync(request.Name);
                await _frameworkBusinessRules.CodingLanguageMustExistForFrameworkOperationsAsync(request.CodingLanguageId);

                Framework framework = _mapper.Map<Framework>(request);
                Framework createdFramework = await _frameworkRepository.AddAsync(framework);
                CreatedFrameworkDto mappedCreatedFrameworkDto = _mapper.Map<CreatedFrameworkDto>(createdFramework);

                return mappedCreatedFrameworkDto;
            }
        }
    }
}
