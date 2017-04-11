using AutoMapper;
using VkHunter.Web.Mapping.Profiles;

namespace VkHunter.Web.Mapping
{
    public class AutoMapperConfiguration
    {
        public static IMapper CreateMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntityToDTOMappingProfile>();
                cfg.AddProfile<DTOToEntitylMappingProfile>();
                cfg.AddProfile<VkModelToEntityMappingProfile>();
            }).CreateMapper();
        }
    }
}
