using AutoMapper;
using VkHunter.BusinessLogic.Mapping.Profiles;

namespace VkHunter.BusinessLogic.Mapping
{
    public class AutoMapperConfiguration
    {
        public static IMapper CreateMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApiModelToVkModelMappingProfile>();
            }).CreateMapper();
        }
    }
}
