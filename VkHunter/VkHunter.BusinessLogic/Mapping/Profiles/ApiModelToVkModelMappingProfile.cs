using System;
using System.Collections.Generic;
using AutoMapper;
using VkHunter.BusinessLogic.Models;
using VkHunter.BusinessLogic.Models.Execute;
using VkHunter.Common.Helpers;
using VkNet.Model;
using Attachment = VkNet.Model.Attachments.Attachment;
using Photo = VkNet.Model.Attachments.Photo;

namespace VkHunter.BusinessLogic.Mapping.Profiles
{
    public class ApiModelToVkModelMappingProfile : Profile
    {
        public ApiModelToVkModelMappingProfile()
        {
            CreateMap<Group, VkGroup>()
                .ForMember(x => x.Ava, y => y.MapFrom(z => z.Photo200.AbsoluteUri))
                .ForMember(x => x.Name, y => y.MapFrom(z => CommonHelper.GetReg(z.Name)))
                .ForMember(x => x.Uri, y => y.MapFrom(z => $"https://vk.com/{z.ScreenName}"))
                .ForMember(x => x.Description, y => y.MapFrom(z => CommonHelper.GetReg(z.Description)));
                
            
            CreateMap<User, VkUser>()
                .ForMember(x => x.Ava, y => y.MapFrom(z => z.Photo200.AbsoluteUri))
                .ForMember(x => x.Name, y => y.MapFrom(z => $"{CommonHelper.GetReg(z.FirstName)} {CommonHelper.GetReg(z.LastName)}"))
                .ForMember(x => x.Uri, y => y.MapFrom(z => $"https://vk.com/{z.Domain}"))
                .ForMember(x => x.Status, y => y.MapFrom(z => CommonHelper.GetReg(z.Status)))
                .ForMember(x => x.MembersCount, y => y.MapFrom(z => z.Counters.Followers)); // Только подписчики. Друзья?

            CreateMap<NewsSearchResult, VkPost>()
                .ForMember(x => x.PhotoUri, opt => opt.ResolveUsing(z => ResolvePhoto(z.Attachments)))
                .ForMember(x => x.Text, y => y.MapFrom(z => CommonHelper.GetReg(z.Text)));

            CreateMap<VkOriginUser, VkUser>()
                .ForMember(x => x.Name, y => y.MapFrom(z => $"{z.Name} {z.SecondName}"))
                .ForMember(x => x.Uri, y => y.MapFrom(z => $"https://vk.com/{z.Uri}"))
                .ForMember(x => x.Status, y => y.MapFrom(z => CommonHelper.GetReg(z.Status)))
                .ForMember(x => x.Site, y => y.MapFrom(z => CommonHelper.GetReg(z.Site)));

            CreateMap<VkExPost, VkPost>()
                .ForMember(x => x.Text, y => y.MapFrom(z => CommonHelper.GetReg(z.Text)))
                .ForMember(x => x.DateTime, y => y.MapFrom(z => UnixTimeStampToDateTime(z.DateTime)))
                .ForMember(x => x.PhotoUri, y => y.MapFrom(z => ResolvePhoto2(z.Attachments)));

            CreateMap<VkExGroup, VkGroup>()
                .ForMember(x => x.Name, y => y.MapFrom(z => CommonHelper.GetReg(z.Name)))
                .ForMember(x => x.Uri, y => y.MapFrom(z => $"https://vk.com/{z.Domain}"))
                .ForMember(x => x.Description, y => y.MapFrom(z => CommonHelper.GetReg(z.Status)));

            CreateMap<VkExUser, VkUser>()
                .ForMember(x => x.Name, y => y.MapFrom(z => $"{z.FirstName} {z.LastName}"))
                .ForMember(x => x.Uri, y => y.MapFrom(z => $"https://vk.com/{z.Domain}"))
                .ForMember(x => x.Status, y => y.MapFrom(z => CommonHelper.GetReg(z.Description)));

            CreateMap<VkOrginExecute, VkExecute>();

            CreateMap<Market, VkMarket>();
        }

        private IList<string> ResolvePhoto(IEnumerable<Attachment> attachments)
        {
            var photos = new List<string>();

            foreach (var attachment in attachments)
            {
                if (attachment.Type.Name == "Photo")
                {
                    var photo = (Photo)attachment.Instance;
                    photos.AddPhotoUri(photo.Photo1280?.AbsoluteUri);
                    photos.AddPhotoUri(photo.Photo130?.AbsoluteUri);
                    photos.AddPhotoUri(photo.Photo2560?.AbsoluteUri);
                    photos.AddPhotoUri(photo.Photo604?.AbsoluteUri);
                    photos.AddPhotoUri(photo.Photo75?.AbsoluteUri);
                    photos.AddPhotoUri(photo.Photo807?.AbsoluteUri);
                }
            }
        
            return photos;
        }

        private IList<string> ResolvePhoto2(IEnumerable<Models.Execute.Attachment> attachments)
        {
            var photos = new List<string>();

            foreach (var attachment in attachments)
            {
                if (attachment.Type == "photo")
                {
                    photos.AddPhotoUri(attachment.Photos.Photo75);
                    photos.AddPhotoUri(attachment.Photos.Photo130);
                    photos.AddPhotoUri(attachment.Photos.Photo604);
                }
            }

            return photos;
        }

        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            return dtDateTime;
        }
    }

    static class PhotoExtantion
    {
        public static void AddPhotoUri(this IList<string> list, string uri)
        {
            if (!string.IsNullOrWhiteSpace(uri))
                list.Add(uri);
        }
    }
}
