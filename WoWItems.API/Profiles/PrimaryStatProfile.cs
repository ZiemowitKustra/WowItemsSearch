using AutoMapper;

namespace WoWItems.API.Profiles
{
    public class PrimaryStatProfile : Profile
    {
        public PrimaryStatProfile()
        {
            CreateMap<Entities.PrimaryStat, Models.PrimaryStatDto>();
        }
    }
}
