using AutoMapper;
using VkHunter.Domain.Entities;
using VkHunter.DTO;

namespace VkHunter.Web.Mapping.Profiles
{
    public class DTOToEntitylMappingProfile : Profile
    {
        public DTOToEntitylMappingProfile()
        {
            CreateMap<ProjectRequestDTO, Project>();

            CreateMap<SearchRequestDTO, Search>();

            CreateMap<MemberRequestDTO, Member>()
                .ForMember(x => x.Project, y => y.Ignore());

            CreateMap<PostRequestDTO, Post>();

            CreateMap<MarketRequestDTO, Market>();

            CreateMap<HistoryRequestDTO, History>();
        }
    }
}
