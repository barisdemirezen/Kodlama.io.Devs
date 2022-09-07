using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.CreateCodingLanguage;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.UpdateCodingLanguage;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Models;
using Kodlama.io.Devs.Domain.Entities;
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
            CreateMap<CodingLanguage, CodingLanguageListModel>();
            CreateMap<CodingLanguage, CodingLanguageListDto>();
            CreateMap<CodingLanguage, CodingLanguageGetByIdDto>();
            CreateMap<CodingLanguage, CreatedCodingLanguageDto>();
            CreateMap<CodingLanguage, DeletedCodingLanguageDto>();
            CreateMap<IPaginate<CodingLanguage>, CodingLanguageListModel>();
            CreateMap<CreateCodingLanguageCommand, CodingLanguage>();
            CreateMap<UpdateCodingLanguageCommand, CodingLanguage>();
            CreateMap<CodingLanguage, UpdatedCodingLanguageDto>();
        }
    }
}
