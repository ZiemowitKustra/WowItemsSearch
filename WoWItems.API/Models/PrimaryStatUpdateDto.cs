namespace WoWItems.API.Models
{
    public class PrimaryStatUpdateDto
    {
        public int itemId { get; set; }
        public PrimaryStatType PrimaryStatType { get; set; }
        public int Value { get; set; }
    }
}
