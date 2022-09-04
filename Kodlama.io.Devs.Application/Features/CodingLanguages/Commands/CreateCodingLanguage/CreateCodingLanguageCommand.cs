using AutoMapper;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.CreateCodingLanguage
{
    public class CreateCodingLanguageCommand : IRequest<CreatedCodingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateCodingLanguageCommandHandler : IRequestHandler<CreateCodingLanguageCommand, CreatedCodingLanguageDto>
        {
            private readonly ICodingLanguageRepository _codingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly CodingLanguageBusinessRules _codingLanguageBusinessRules;
            public CreateCodingLanguageCommandHandler(ICodingLanguageRepository codingLanguageRepository, IMapper mapper, CodingLanguageBusinessRules codingLanguageBusinessRules)
            {
                _mapper = mapper;
                _codingLanguageRepository = codingLanguageRepository;
                _codingLanguageBusinessRules = codingLanguageBusinessRules;
            }
            public async Task<CreatedCodingLanguageDto> Handle(CreateCodingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _codingLanguageBusinessRules.CodingLanguageNameCannotBeRepeatedWhenInsertedAsync(request.Name);

                CodingLanguage codingLanguage = _mapper.Map<CodingLanguage>(request);
                CodingLanguage createdCodingLanguage = await _codingLanguageRepository.AddAsync(codingLanguage);
                CreatedCodingLanguageDto mappedCreatedCodingLanguageDto = _mapper.Map<CreatedCodingLanguageDto>(createdCodingLanguage);
                return mappedCreatedCodingLanguageDto;
            }
        }
    }
}
