using System.Linq;
using AutoMapper;
using VkHunter.Domain.Entities;
using VkHunter.DTO;

namespace VkHunter.Web.Mapping.Profiles
{
    public class EntityToDTOMappingProfile : Profile
    {
        public EntityToDTOMappingProfile()
        {
            CreateMap<Project, ProjectResponseDTO>();

            CreateMap<Search, SearchResponseDTO>();

            CreateMap<Member, MemberResponseDTO>();

            CreateMap<Post, PostResponseDTO>();

            CreateMap<Market, MarketResponseDTO>();

            CreateMap<History, HistoryRequestDTO>();
        }
    }
}
