using AutoMapper;

namespace WoWItems.API.Profiles
{
    public class PrimaryStatProfile : Profile
    {
        public PrimaryStatProfile()
        {
            CreateMap<Entities.PrimaryStat, Models.PrimaryStatDto>();
            CreateMap<Models.PrimaryStatDto, Entities.PrimaryStat>();
            CreateMap<Models.PrimaryStatCreationDto, Entities.PrimaryStat>();
            CreateMap<Models.PrimaryStatUpdateDto, Entities.PrimaryStat>();
        }
    }
}
