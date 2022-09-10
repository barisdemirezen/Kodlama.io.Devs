using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
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

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateFramework
{
    public class UpdateFrameworkCommand : IRequest<UpdatedFrameworkDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CodingLanguageId { get; set; }

        public class UpdatedFrameworkCommandHandler : IRequestHandler<UpdateFrameworkCommand, UpdatedFrameworkDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly FrameworkBusinessRules _frameworkBusinessRules;
            
            public UpdatedFrameworkCommandHandler(IMapper mapper, IFrameworkRepository frameworkRepository, FrameworkBusinessRules frameworkBusinessRules)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
                _frameworkBusinessRules = frameworkBusinessRules;
            }

            public async Task<UpdatedFrameworkDto> Handle(UpdateFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework? framework = await _frameworkRepository.GetAsync(e => e.Id == request.Id);

                if (framework == null)
                    throw new NotFoundException("Framework not found");
                
                await _frameworkBusinessRules.CodingLanguageMustExistForFrameworkOperationsAsync(request.CodingLanguageId);
                await _frameworkBusinessRules.FrameworkNameCannotBeRepeatedWhenInsertedAsync(request.Name);

                framework = _mapper.Map(request, framework);

                await _frameworkRepository.UpdateAsync(framework);

                UpdatedFrameworkDto mappedUpdatedFrameworkDto = _mapper.Map<UpdatedFrameworkDto>(framework);

                return mappedUpdatedFrameworkDto;
            }
        }
    }
}
