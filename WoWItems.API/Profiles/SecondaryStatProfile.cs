using AutoMapper;
using WoWItems.API.Models.Stats.SecondaryStat;

namespace WoWItems.API.Profiles
{
    public class SecondaryStatProfile : Profile
    {
        public SecondaryStatProfile()
        {
            CreateMap<Entities.SecondaryStat, SecondaryStatDto>();
            CreateMap<SecondaryStatDto, Entities.SecondaryStat>();
            CreateMap<SecondaryStatCreationDto, Entities.SecondaryStat>();
            //CreateMap<Entities.SecondaryStat, Models.SecondaryStatCreationDto>();
            CreateMap<SecondaryStatUpdateDto, Entities.SecondaryStat>();
            //CreateMap<Entities.SecondaryStat, Models.SecondaryStatUpdateDto>();
        }
    }
}
