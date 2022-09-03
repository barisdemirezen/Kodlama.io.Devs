using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.CodingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.CodingLanguage, Models.CodingLanguageListModel>();
            CreateMap<Domain.Entities.CodingLanguage, Dtos.CodingLanguageListDto>();
            CreateMap<Domain.Entities.CodingLanguage, Dtos.CodingLanguageGetByIdDto>();
            CreateMap<Domain.Entities.CodingLanguage, Dtos.CreatedCodingLanguageDto>();
        }
    }
}
