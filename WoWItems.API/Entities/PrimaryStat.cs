using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WoWItems.API.Models;

namespace WoWItems.API.Entities
{
    public class PrimaryStat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public PrimaryStatType PrimaryStatType { get; set; }
        public int Value { get; set; }

        [ForeignKey("ItemId")]
        public Item? Item { get; set; }
        public int ItemId { get; set; }
    }
}
