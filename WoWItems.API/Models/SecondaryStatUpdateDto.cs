namespace WoWItems.API.Models
{
    public class SecondaryStatUpdateDto
    {
        public int ItemId { get; set; }
        public SecondaryStatType SecondaryStatType { get; set; }
        public int Value { get; set; }
    }
}
