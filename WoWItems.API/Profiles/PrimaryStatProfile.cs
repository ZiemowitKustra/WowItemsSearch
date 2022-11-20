using AutoMapper;
using WoWItems.API.Models.Stats.PrimaryStat;

namespace WoWItems.API.Profiles
{
    public class PrimaryStatProfile : Profile
    {
        public PrimaryStatProfile()
        {
            CreateMap<Entities.PrimaryStat, PrimaryStatDto>();
            CreateMap<PrimaryStatDto, Entities.PrimaryStat>();
            CreateMap<PrimaryStatCreationDto, Entities.PrimaryStat>();
            CreateMap<PrimaryStatUpdateDto, Entities.PrimaryStat>();
        }
    }
}
