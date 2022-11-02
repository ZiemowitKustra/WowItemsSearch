using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWItems.API.Entities;
using WoWItems.API.Models;
using WoWItems.API.Services;

namespace WoWItems.Test.Services
{
    internal class WoWItemsTestRepository : IWoWItemsRepository
    {
        private List<Item> _items;
        private List<PrimaryStat> _primaryStat;
        private List<SecondaryStat> _secondaryStat;

        public WoWItemsTestRepository()
        {

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

        public Task<IEnumerable<Item>> GetItemsAsync(string? name, PrimaryStatType? primaryStat, SecondaryStatType? secondaryStat, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public PrimaryStat? GetPrimaryStat(int itemId, PrimaryStatType primaryStat)
        {
            return _primaryStat.FirstOrDefault(p => p.ItemId == itemId && p.PrimaryStatType == primaryStat);
        }
        public Task<PrimaryStat?> GetStatAsync(int itemId, PrimaryStatType primaryStatType)
        {
            return Task.FromResult(GetPrimaryStat(itemId, primaryStatType));
        }

        public Task<SecondaryStat?> GetStatAsync(int itemId, SecondaryStatType secondaryStatType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ItemExistsAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync(CancellationToken token = default)
        {
            //empty on perpouse
            return Task.CompletedTask;
        }

        public Task<bool> StatExistsAsync(int itemId, SecondaryStatType secondaryStatType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> StatExistsAsync(int itemId, PrimaryStatType primaryStatType)
        {
            throw new NotImplementedException();
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
