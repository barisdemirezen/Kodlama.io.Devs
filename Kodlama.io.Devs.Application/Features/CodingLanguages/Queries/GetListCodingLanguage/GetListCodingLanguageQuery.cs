using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.CodingLanguages.Queries.GetListCodingLanguage
{
    public class GetListCodingLanguageQuery : IRequest<CodingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListCodingLanguageQueryHandler : IRequestHandler<GetListCodingLanguageQuery, CodingLanguageListModel>
        {
            private readonly ICodingLanguageRepository _codingLanguageRepository;
            private readonly IMapper _mapper;

            public GetListCodingLanguageQueryHandler(ICodingLanguageRepository codingLanguageRepository, IMapper mapper)
            {
                _codingLanguageRepository = codingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<CodingLanguageListModel> Handle(GetListCodingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<CodingLanguage> codingLanguages = await _codingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                CodingLanguageListModel mappedCodingLanguageListModel = _mapper.Map<CodingLanguageListModel>(codingLanguages);
                return mappedCodingLanguageListModel;
            }
        }

    }
}
