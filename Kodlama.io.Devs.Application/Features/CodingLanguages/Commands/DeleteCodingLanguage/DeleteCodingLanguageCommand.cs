using AutoMapper;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.DeleteCodingLanguage
{
    public class DeleteCodingLanguageCommand : IRequest<DeletedCodingLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteCodingLanguageCommandHandler : IRequestHandler<DeleteCodingLanguageCommand, DeletedCodingLanguageDto>
        {
            private readonly ICodingLanguageRepository _codingLanguageRepository;
            private readonly IMapper _mapper;
            public DeleteCodingLanguageCommandHandler(ICodingLanguageRepository codingLanguageRepository, IMapper mapper)
            {
                _codingLanguageRepository = codingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeletedCodingLanguageDto> Handle(DeleteCodingLanguageCommand request, CancellationToken cancellationToken)
            {
                CodingLanguage? codingLanguage = await _codingLanguageRepository.GetAsync(e => e.Id == request.Id);
                _codingLanguageRepository.Delete(codingLanguage);
                DeletedCodingLanguageDto mappedDeletedCodingLanguageDto = _mapper.Map<DeletedCodingLanguageDto>(codingLanguage);
                return mappedDeletedCodingLanguageDto;
            }
        }
    }
}
