using WoWItems.API.Entities;
using WoWItems.API.Models.Drop;
using WoWItems.API.Models.Stats.SecondaryStat;
using WoWItems.API.Models.ItemToSlotType.Armor;
using WoWItems.API.Models.ItemToSlotType.Weapon;


namespace WoWItems.API.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        public ItemType Type { get; set; }
        public WeaponDto? Weapon { get; set; } //fields connected with Item type - or weapon
        public ArmorDto? ArmorFields { get; set; } //fields connected with Item type - of Armor
        public string Name { get; set; } = string.Empty;
        public int? Armor { get; set; } //Statistic that reduce dmg taken
        public ICollection<PrimaryStat> PrimaryStat { get; set; } 
            = new List<PrimaryStat>();
        public int? Stamina { get; set; }
        public ICollection<SecondaryStatDto> SecondaryStats { get; set; }
            = new List<SecondaryStatDto>();
        public string? EquipEffect { get; set; }
        public string? UseEffect { get; set; }
        public int Durability { get; set; }
        public ICollection<MobDropDto> MobDrop { get; set; }
            = new List<MobDropDto>();

    }
}
