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

namespace Kodlama.io.Devs.Application.Features.CodingLanguages.Queries.GetByIdCodingLanguage
{
    public class GetByIdCodingLanguageQuery : IRequest<CodingLanguageGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdCodingLanguageQueryHandler : IRequestHandler<GetByIdCodingLanguageQuery, CodingLanguageGetByIdDto>
        {
            private readonly ICodingLanguageRepository _codingLanguageRepository;
            private readonly IMapper _mapper;
            public GetByIdCodingLanguageQueryHandler(ICodingLanguageRepository codingLanguageRepository, IMapper mapper)
            {
                _codingLanguageRepository = codingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<CodingLanguageGetByIdDto> Handle(GetByIdCodingLanguageQuery request, CancellationToken cancellationToken)
            {
                CodingLanguage? codingLanguage = await _codingLanguageRepository.GetAsync(e => e.Id == request.Id);

                if (codingLanguage == null)
                    throw new NotFoundException("Coding language not found");

                CodingLanguageGetByIdDto mappedCodingLanguageGetByIdDto = _mapper.Map<CodingLanguageGetByIdDto>(codingLanguage);
                return mappedCodingLanguageGetByIdDto;
            }
        }
    }
}
