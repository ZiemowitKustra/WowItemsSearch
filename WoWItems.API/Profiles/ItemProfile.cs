using AutoMapper;

namespace WoWItems.API.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Entities.Item, Models.ItemDto>();
        }
    }
}
