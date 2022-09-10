using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByCodingLanguageIdFramework
{
    public class GetByCodingLanguageIdFrameworkQuery : IRequest<FrameworkListModel>
    {
        public int CodingLanguageId { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetByCodingLanguageIdFrameworkQueryHandler : IRequestHandler<GetByCodingLanguageIdFrameworkQuery, FrameworkListModel>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;

            public GetByCodingLanguageIdFrameworkQueryHandler(IMapper mapper, IFrameworkRepository frameworkRepository)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
            }

            public async Task<FrameworkListModel> Handle(GetByCodingLanguageIdFrameworkQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Framework> frameworks = await _frameworkRepository.GetListAsync(e => e.CodingLanguageId == request.CodingLanguageId, index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                FrameworkListModel mappedFrameworkListModel = _mapper.Map<FrameworkListModel>(frameworks);

                return mappedFrameworkListModel;
            }
        }
    }
}
