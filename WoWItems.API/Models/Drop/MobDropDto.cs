namespace WoWItems.API.Models.Drop
{
    public class MobDropDto
    {
        public int MobId { get; set; }
        public float DropChance { get; set; }
        public List<string>? MobLocations { get; set; } = new List<string>();
    }
}