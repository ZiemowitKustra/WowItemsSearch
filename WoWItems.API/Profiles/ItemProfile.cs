using AutoMapper;

namespace WoWItems.API.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Entities.Item, Models.ItemDto>();
            CreateMap<Models.ItemDto, Entities.Item>();
            CreateMap<Models.ItemCreationDto, Entities.Item>();
        }
    }
}
