using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWItems.API.Entities;
using WoWItems.API.Models;
using WoWItems.API.Models.Stats.PrimaryStat;
using WoWItems.API.Models.Stats.SecondaryStat;
using WoWItems.API.Services;

namespace WoWItems.Test.Services
{
    internal class WoWItemsTestRepository : IWoWItemsRepository
    {
        private List<Item> _items = null!;
        private List<PrimaryStat> _primaryStat = null!;
        private List<SecondaryStat> _secondaryStat = null!;

        public WoWItemsTestRepository()
        {
            _items = new()
            {
                new Item("RandomItem1")
                {
                    Id = 1,
                    Type = ItemType.Weapon,
                    Armor = 0,
                    Stamina = 12,
                    EquipEffect = "Deals 5 fire dmg to anyone who strikes you with mele attack",
                    Durability = 145
                },
                new Item("RandomItem2")
                {
                    Id = 2,
                    Type = ItemType.Armor,
                    Armor = 679,
                    Stamina = 81,
                    Durability = 120
                },
                new Item("RandomItem3")
                {
                    Id = 3,
                    Type = ItemType.Armor,
                    Armor = 486,
                    Stamina = 54,
                    Durability = 25,
                    UseEffect = "Deal Test Dmg to random developer per years worked",
                }
            };
            _primaryStat = new()
            {
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
                    PrimaryStatType = PrimaryStatType.Agility,
                    Value = 12,
                    ItemId = 2
                },
                new PrimaryStat()
                {
                    Id = 3,
                    PrimaryStatType = PrimaryStatType.Intelect,
                    Value = 12,
                    ItemId = 3
                },
                new PrimaryStat()
                {
                    Id = 4,
                    PrimaryStatType = PrimaryStatType.Strenght,
                    Value = 12,
                    ItemId = 3
                },
            };
            _secondaryStat = new()
            {
                new SecondaryStat()
                {
                    Id = 1,
                    SecondaryStatType = SecondaryStatType.Avoidance,
                    Value = 21,
                    ItemId = 1
                },
                new SecondaryStat()
                {
                    Id = 2,
                    SecondaryStatType = SecondaryStatType.Speed,
                    Value = 21,
                    ItemId = 1
                },
                new SecondaryStat()
                {
                    Id = 3,
                    SecondaryStatType = SecondaryStatType.Versatility,
                    Value = 21,
                    ItemId = 2
                },
                new SecondaryStat()
                {
                    Id = 4,
                    SecondaryStatType = SecondaryStatType.Mastery,
                    Value = 21,
                    ItemId = 2
                },
                new SecondaryStat()
                {
                    Id = 5,
                    SecondaryStatType = SecondaryStatType.Haste,
                    Value = 21,
                    ItemId = 3
                },
                new SecondaryStat()
                {
                    Id = 6,
                    SecondaryStatType = SecondaryStatType.CriticalStrike,
                    Value = 21,
                    ItemId = 3

                },
            };
        }
        public Task AddItemAsync(Item item)
        {
            return Task.CompletedTask;
        }

        public Task AddPrimaryStatToItemAsync(int itemId, PrimaryStat primaryStat)
        {
            return Task.CompletedTask;
        }

        public Task AddSecondaryStatToItemAsync(int itemId, SecondaryStat secondaryStat)
        {
            return Task.CompletedTask;
        }

        public Task DeleteItemAsync(Item item)
        {

            return Task.CompletedTask;
        }

        public Item? GetItem(int itemId)
        {
            return _items.FirstOrDefault(i => i.Id == itemId);
        }

        public Task<Item?> GetItemAsync(int itemId)
        {
            return Task.FromResult(GetItem(itemId));
        }

        public Task<IEnumerable<Item>> GetItemsAsync()
        {
            return Task.FromResult((IEnumerable<Item>)_items);
        }

        //public IEnumerable<Item> GetItems(string? name, PrimaryStatType? primaryStat, SecondaryStatType? secondaryStat, int pageNumber, int pageSize)
        //{
        //    return; 
        //}
        public Task<IEnumerable<Item>> GetItemsAsync(string? name, PrimaryStatType? primaryStat, SecondaryStatType? secondaryStat, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
            //return Task.FromResult()
        }

        public PrimaryStat? GetPrimaryStat(int itemId, PrimaryStatType primaryStat)
        {
            return _primaryStat.FirstOrDefault(p => p.ItemId == itemId && p.PrimaryStatType == primaryStat);
        }
        public Task<PrimaryStat?> GetStatAsync(int itemId, PrimaryStatType primaryStatType)
        {
            return Task.FromResult(GetPrimaryStat(itemId, primaryStatType));
        }

        public SecondaryStat? GetSecondaryStat(int itemId, SecondaryStatType secondaryStat)
        {
            return _secondaryStat.FirstOrDefault(s => s.ItemId == itemId && s.SecondaryStatType == secondaryStat);
        }

        public Task<SecondaryStat?> GetStatAsync(int itemId, SecondaryStatType secondaryStatType)
        {
            return Task.FromResult(GetSecondaryStat(itemId, secondaryStatType));
        }

        public Task<bool> ItemExistsAsync(int itemId)
        {
            return Task.FromResult(true);
        }

        public Task SaveChangesAsync(CancellationToken token = default)
        {
            //empty on perpouse
            return Task.CompletedTask;
        }

        public Task<bool> StatExistsAsync(int itemId, SecondaryStatType secondaryStatType)
        {
            return Task.FromResult(true);
        }

        public Task<bool> StatExistsAsync(int itemId, PrimaryStatType primaryStatType)
        {
            return Task.FromResult(true);
        }

        public Task UpdateStatAsync(PrimaryStat primaryStat)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatAsync(SecondaryStat secondaryStat)
        {
            throw new NotImplementedException();
        }
    }
}
