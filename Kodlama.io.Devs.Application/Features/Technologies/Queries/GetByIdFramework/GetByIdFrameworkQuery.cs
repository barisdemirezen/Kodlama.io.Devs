using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdFramework
{
    public class GetByIdFrameworkQuery : IRequest<FrameworkGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdFrameworkQueryHandler : IRequestHandler<GetByIdFrameworkQuery, FrameworkGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;

            public GetByIdFrameworkQueryHandler(IMapper mapper, IFrameworkRepository frameworkRepository)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
            }

            public async Task<FrameworkGetByIdDto> Handle(GetByIdFrameworkQuery request, CancellationToken cancellationToken)
            {
                Framework? framework = await _frameworkRepository.GetAsync(e => e.Id == request.Id);

                if (framework == null)
                    throw new NotFoundException("Framework not found");

                FrameworkGetByIdDto mappedFrameworkGetByIdDto = _mapper.Map<FrameworkGetByIdDto>(framework);

                return mappedFrameworkGetByIdDto;
            }
        }
    }
}
