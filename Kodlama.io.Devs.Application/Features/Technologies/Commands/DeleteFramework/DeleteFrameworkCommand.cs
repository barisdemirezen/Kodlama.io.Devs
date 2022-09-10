﻿using AutoMapper;
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
    public class DeleteFrameworkCommand : IRequest<DeletedFrameworkDto>
    {
        public int Id { get; set; }
        public class DeletedrameworkCommandHandler : IRequestHandler<DeleteFrameworkCommand, DeletedFrameworkDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;

            public DeletedrameworkCommandHandler(IMapper mapper, IFrameworkRepository frameworkRepository)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
            }
            public async Task<DeletedFrameworkDto> Handle(DeleteFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework? framework = await _frameworkRepository.GetAsync(e => e.Id == request.Id);

                if (framework == null)
                    throw new NotFoundException("Framework not found");

                await _frameworkRepository.DeleteAsync(framework);

                DeletedFrameworkDto mappedDeletedFrameworkDto = _mapper.Map<DeletedFrameworkDto>(framework);

                return mappedDeletedFrameworkDto;
            }
        }
    }
}
