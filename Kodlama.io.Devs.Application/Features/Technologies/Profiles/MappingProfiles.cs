using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateFramework;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteFramework;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateFramework;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateFrameworkCommand, Framework>();
            CreateMap<UpdateFrameworkCommand, Framework>();
            CreateMap<DeleteFrameworkCommand, Framework>();

            CreateMap<Framework, DeletedFrameworkDto>();
            CreateMap<Framework, CreatedFrameworkDto>();
            CreateMap<Framework, UpdatedFrameworkDto>();
            
            CreateMap<Framework, FrameworkGetByIdDto>();
            CreateMap<Framework, FrameworkListDto>();

            CreateMap<IPaginate<Framework>, FrameworkListModel>();
            
        }
    }
}
