using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WoWItems.API.Models;

namespace WoWItems.API.Entities
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ItemType Type { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public int? Armor { get; set; }

        public ICollection<PrimaryStat> PrimaryStat { get; set; } = new List<PrimaryStat>();
        public int Stamina { get; set; }
        public ICollection<SecondaryStat> SecondaryStats { get; set; }
            = new List<SecondaryStat>();
        public string? EquipEffect { get; set; } = string.Empty;
        public string? UseEffect { get; set; } = string.Empty;
        public int Durability { get; set; }

        public Item(string name)
        {
            Name = name;
        }

    }
}
