using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WoWItems.API.Models;

namespace WoWItems.API.Entities
{
    public class SecondaryStat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public SecondaryStatType SecondaryStatType { get; set; }
        public int Value { get; set; }

        [ForeignKey("ItemId") ]
        public Item? Item { get; set; }
        public int ItemId { get; set; }


    }
}
