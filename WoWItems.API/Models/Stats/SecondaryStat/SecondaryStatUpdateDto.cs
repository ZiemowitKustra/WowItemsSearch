namespace WoWItems.API.Models.Stats.SecondaryStat
{
    public class SecondaryStatUpdateDto
    {
        public int ItemId { get; set; }
        public SecondaryStatType SecondaryStatType { get; set; }
        public int Value { get; set; }
    }
}
