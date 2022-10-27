namespace WoWItems.API.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        public ItemType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Armor { get; set; }
        public PrimaryStatDto? PrimaryStat { get; set; }
        public int? Stamina { get; set; }
        public ICollection<SecondaryStatDto> SecondaryStats { get; set; }
            = new List<SecondaryStatDto>();
        public string? EquipEffect { get; set; }
        public string? UseEffect { get; set; }
        public int Durability { get; set; }
        public ICollection<MobDrop> MobDrop { get; set; }
            = new List<MobDrop>();

    }
}
