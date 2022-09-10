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

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteFramework
{
    public class DeletedFrameworkCommand : IRequest<DeletedFrameworkDto>
    {
        public int Id { get; set; }
        public class DeletedFrameworkCommandHandler : IRequestHandler<DeletedFrameworkCommand, DeletedFrameworkDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;

            public DeletedFrameworkCommandHandler(IMapper mapper, IFrameworkRepository frameworkRepository)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
            }
            public async Task<DeletedFrameworkDto> Handle(DeletedFrameworkCommand request, CancellationToken cancellationToken)
            {
                // id cannot be null

                Framework framework = await _frameworkRepository.GetAsync(e => e.Id == request.Id);

                if (framework == null)
                    throw new NotFoundException("Framework not found");

                await _frameworkRepository.DeleteAsync(framework);

                DeletedFrameworkDto mappedDeletedFrameworkDto = _mapper.Map<DeletedFrameworkDto>(framework);

                return mappedDeletedFrameworkDto;
            }
        }
    }
}
