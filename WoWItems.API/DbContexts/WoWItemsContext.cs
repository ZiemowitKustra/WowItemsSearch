using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Text;
using WoWItems.API.Entities;
using WoWItems.API.Models;

namespace WoWItems.API.DbContexts
{
    public class WoWItemsContext : DbContext
    {
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<PrimaryStat> PrimaryStat { get; set; } = null!;
        public DbSet<SecondaryStat> SecondaryStat { get; set; } = null!;
        public WoWItemsContext(DbContextOptions<WoWItemsContext> options) : base(options)
        {

        }

        public WoWItemsContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add requirements on id
            modelBuilder.Entity<Item>()
                    .Property(i => i.Id)
                    .IsRequired();
            //filling database
            modelBuilder.Entity<Item>().HasData(
                new Item("Sulfuras, Hand of Ragnaros")
                {
                    Id = 1,
                    Type = ItemType.Weapon,
                    Armor = 0,
                    Stamina = 12,
                    EquipEffect = "Deals 5 fire dmg to anyone who strikes you with mele attack",
                    Durability = 145
                },
                new Item("Ruined Crest of Lorderon")
                {
                    Id = 2,
                    Type = ItemType.Armor,
                    Armor = 679,
                    Stamina = 81,
                    Durability = 120,
                });
            modelBuilder.Entity<PrimaryStat>().HasData(
                new PrimaryStat()
                {
                    Id = 1,
                    PrimaryStatType = PrimaryStatType.Strenght,
                    Value = 12,
                    ItemId = 1
                },
                new PrimaryStat()
                {
                    Id = 2,
                    PrimaryStatType = PrimaryStatType.Intelect,
                    Value = 133,
                    ItemId = 2
                });
            modelBuilder.Entity<SecondaryStat>().HasData(
                new SecondaryStat()
                {
                    Id = 1,
                    SecondaryStatType = SecondaryStatType.Mastery,
                    Value = 21,
                    ItemId = 2
                },
                new SecondaryStat()
                {
                    Id = 2,
                    SecondaryStatType = SecondaryStatType.Haste,
                    Value = 52,
                    ItemId = 2
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
