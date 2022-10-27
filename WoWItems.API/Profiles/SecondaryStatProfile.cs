using AutoMapper;

namespace WoWItems.API.Profiles
{
    public class SecondaryStatProfile : Profile
    {
        public SecondaryStatProfile()
        {
            CreateMap<Entities.SecondaryStat, Models.SecondaryStatDto>();
        }
    }
}
