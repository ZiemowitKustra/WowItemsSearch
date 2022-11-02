
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WoWItems.API.DbContexts;
using WoWItems.API.Entities;
using WoWItems.API.Models;

namespace WoWItems.API.Services
{
    public class WoWItemsRepository : IWoWItemsRepository
    {
        private readonly WoWItemsContext _context;

        public WoWItemsRepository(WoWItemsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddPrimaryStatToItemAsync(int itemId, PrimaryStat primaryStat)
        {
            var item = await GetItemAsync(itemId);
            if (item != null)
            {
                item.PrimaryStat.Add(primaryStat);
            }
        }

        public async Task AddSecondaryStatToItemAsync(int itemId, SecondaryStat secondaryStat)
        {
            var item = await GetItemAsync(itemId);
            if(item != null)
            {
                item.SecondaryStats.Add(secondaryStat);
            }
        }

        public async Task<Item?> GetItemAsync(int itemId)
        {
            return await _context.Items
                .Include(i => i.PrimaryStat)
                .Include(i => i.SecondaryStats)
                .Where(i => i.Id == itemId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _context.Items
                .Include(i => i.PrimaryStat)
                .Include(i => i.SecondaryStats)
                .OrderBy(i => i.Name).ToListAsync();
        }

        public async Task<PrimaryStat?> GetStatAsync(int itemId, PrimaryStatType primaryStatType)
        {
            return await _context.PrimaryStat.Where(s => s.ItemId == itemId
            && s.PrimaryStatType == primaryStatType).FirstOrDefaultAsync();
        }

        public async Task<SecondaryStat?> GetStatAsync(int itemId, SecondaryStatType secondaryStatType)
        {
            return await _context.SecondaryStat.Where(s => s.ItemId == itemId
            && s.SecondaryStatType == secondaryStatType).FirstOrDefaultAsync();
        }

        public async Task<bool> ItemExistsAsync(int itemId)
        {
            return await _context.Items.Where(i => i.Id == itemId).AnyAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> StatExistsAsync(int itemId, SecondaryStatType secondaryStatType)
        {
            return await _context.SecondaryStat
                .Where(s => s.ItemId == itemId && s.SecondaryStatType == secondaryStatType).AnyAsync();
        }

        public async Task<bool> StatExistsAsync(int itemId, PrimaryStatType primaryStatType)
        {
            return await _context.PrimaryStat
                .Where(s => s.ItemId == itemId && s.PrimaryStatType == primaryStatType).AnyAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(
            string? name, PrimaryStatType? primaryStat, SecondaryStatType? secondaryStat, int pageNumber, int pageSize)
        {
            var itemCollection = _context.Items
                .Include(i => i.PrimaryStat)
                .Include(i => i.SecondaryStats) as IQueryable<Item>;

            if (!string.IsNullOrEmpty(name))
            {
                name = name.Trim().ToLower();
                itemCollection = itemCollection.Where(i => i.Name.ToLower().Contains(name));
            }
            if (primaryStat.HasValue)
            {
                itemCollection = itemCollection.Where(i => i.PrimaryStat.Any(p => p.PrimaryStatType == primaryStat));
            }
            if (secondaryStat.HasValue)
            {
                itemCollection = itemCollection.Where(i => i.SecondaryStats.Any(s => s.SecondaryStatType == secondaryStat));
            }

            var itemCollectionToReturn = await itemCollection.OrderBy(i => i.Name)
                                .Skip(pageSize * (pageNumber - 1))
                                .Take(pageSize)
                                .ToListAsync();

            return itemCollectionToReturn;
        }

        public async Task DeleteItemAsync(Item item)
        {
            _context.Items.Remove(item);
            await SaveChangesAsync();
        }

        public async Task AddItemAsync(Item item)
        {
            _context.Items.Add(item);
            await SaveChangesAsync();
        }

        public async Task UpdateStatAsync(PrimaryStat primaryStat)
        {            
            _context.PrimaryStat.Update(primaryStat);
            await SaveChangesAsync();
        }

        public async Task UpdateStatAsync(SecondaryStat secondaryStat)
        {
            _context.SecondaryStat.Update(secondaryStat);
            await SaveChangesAsync();
        }
    }
}
