using System;
using AutoMapper;
using Newtonsoft.Json;
using VkHunter.BusinessLogic.Models;
using VkHunter.Domain.Entities;

namespace VkHunter.Web.Mapping.Profiles
{
    public class VkModelToEntityMappingProfile : Profile
    {
        public VkModelToEntityMappingProfile()
        {
            CreateMap<VkGroup, Member>()
                .ForMember(x => x.VkId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore());

            CreateMap<VkUser, Member>()
                .ForMember(x => x.VkId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore());

            CreateMap<VkMarket, Market>()
                .ForMember(x => x.VkId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore());
            
            CreateMap<VkPost, Post>()
                .ForMember(x => x.VkId, y => y.MapFrom(z => $"{Math.Abs(z.FromId)}_{z.Id}"))
                .ForMember(x => x.PhotoUri, y => y.MapFrom(z => JsonConvert.SerializeObject(z.PhotoUri)))
                .ForMember(x => x.Uri, y => y.MapFrom(z => GetPostUri(z)));
        }

        private string GetPostUri(VkPost post)
        {
            return post.FromId < 0
                ? $"https://vk.com/feed?w=wall-{-post.FromId}_{post.Id}"
                : $"https://vk.com/feed?w=wall{post.FromId}_{post.Id}";
        }
    }
}
