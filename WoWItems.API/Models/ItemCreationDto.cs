using WoWItems.API.Entities;

namespace WoWItems.API.Models
{
    public class ItemCreationDto
    {
        public ItemType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Armor { get; set; }
        public ICollection<PrimaryStatCreationDto> PrimaryStat { get; set; }
            = new List<PrimaryStatCreationDto>();
        public int? Stamina { get; set; }
        public ICollection<SecondaryStatCreationDto> SecondaryStats { get; set; }
            = new List<SecondaryStatCreationDto>();
        public string EquipEffect { get; set; } = string.Empty;
        public string UseEffect { get; set; } = string.Empty;
        public int Durability { get; set; }
    }
}
