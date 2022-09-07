using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.UpdateCodingLanguage
{
    public class UpdateCodingLanguageCommand : IRequest<UpdatedCodingLanguageDto>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public class UpdateCodingLanguageCommandHandler : IRequestHandler<UpdateCodingLanguageCommand, UpdatedCodingLanguageDto>
        {
            private readonly ICodingLanguageRepository _codingLanguageRepository;
            private readonly IMapper _mapper;

            public UpdateCodingLanguageCommandHandler(ICodingLanguageRepository codingLanguageRepository, IMapper mapper)
            {
                _codingLanguageRepository = codingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedCodingLanguageDto> Handle(UpdateCodingLanguageCommand request, CancellationToken cancellationToken)
            {
                CodingLanguage? codingLanguage = await _codingLanguageRepository.GetAsync(e => e.Id == request.Id);

                if (codingLanguage == null)
                    throw new NotFoundException("Coding language not found");

                codingLanguage = _mapper.Map(request, codingLanguage);

                await _codingLanguageRepository.UpdateAsync(codingLanguage);

                UpdatedCodingLanguageDto mappedUpdatedCodingLanguageDto = _mapper.Map<UpdatedCodingLanguageDto>(codingLanguage);

                return mappedUpdatedCodingLanguageDto;
            }
        }
    }
}
