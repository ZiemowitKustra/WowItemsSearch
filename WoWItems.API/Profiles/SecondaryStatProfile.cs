using AutoMapper;

namespace WoWItems.API.Profiles
{
    public class SecondaryStatProfile : Profile
    {
        public SecondaryStatProfile()
        {
            CreateMap<Entities.SecondaryStat, Models.SecondaryStatDto>();
            CreateMap<Models.SecondaryStatDto, Entities.SecondaryStat>();
            CreateMap<Models.SecondaryStatCreationDto, Entities.SecondaryStat>();
            //CreateMap<Entities.SecondaryStat, Models.SecondaryStatCreationDto>();
            CreateMap<Models.SecondaryStatUpdateDto, Entities.SecondaryStat>();
            //CreateMap<Entities.SecondaryStat, Models.SecondaryStatUpdateDto>();
        }
    }
}
