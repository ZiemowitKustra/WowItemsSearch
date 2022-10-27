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

        public Task AddPrimaryStatToItemAsync(int itemId, PrimaryStat primaryStat)
        {
            throw new NotImplementedException();
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

        public async Task<PrimaryStat?> GetStatAsync(int itemId)
        {
            return await _context.PrimaryStat.Where(s => s.ItemId == itemId)
                .FirstOrDefaultAsync();
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

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
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

        /// <summary>
        /// if GetItemsAsync(
        //    string? name, PrimaryStatType? primaryStat, SecondaryStatType? secondaryStat)
        // start working move paging implementation to that method
        /// </summary>
        public async Task<(IEnumerable<Item>, PaginationMetadata)> GetItemsAsync(string? name, PrimaryStatType? primaryStat,
                                                           int pageNumber, int pageSize)
        {
            var collection = _context.Items as IQueryable<Item>;
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(i => i.Name.Contains(name));
            }
            if (primaryStat.HasValue)
            {
                collection = collection.Where(i => i.PrimaryStat.PrimaryStatType == primaryStat);
            }
            var totalItemCount = await collection.CountAsync();
            var paginationMatadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            var collectionToReturn = await collection.Include(i => i.PrimaryStat)
                                   .Include(i => i.SecondaryStats)
                                   .OrderBy(i => i.Name)
                                   .Skip(pageSize * (pageNumber-1))
                                   .Take(pageSize)
                                   .ToListAsync();

            return (collectionToReturn, paginationMatadata);
        }
        ////////////////////////
        //Doesnt work -> how to iterate items if they contein one of secondary stats or both?
        //and add to interface
        ////////////////////////
        //public async Task<IEnumerable<Item>> GetItemsAsync(
        //    string? name, PrimaryStatType? primaryStat, SecondaryStatType? secondaryStat)
        //{
        //    var secondaryCollection = _context.SecondaryStat as IQueryable<SecondaryStat>;
        //    var itemCollection = _context.Items as IQueryable<Item>;
        //    secondaryCollection = secondaryCollection.Where(s => s.SecondaryStatType == secondaryStat);
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        name = name.Trim();
        //        itemCollection = itemCollection.Where(i => i.Name.Contains(name));
        //    }
        //    if (primaryStat.HasValue)
        //    {
        //        itemCollection.Where(i => i.PrimaryStat.PrimaryStatType == primaryStat);
        //    }
        //    return await itemCollection.Where(i => i.SecondaryStats == secondaryCollection)
        //                        .Include(i => i.PrimaryStat)
        //                        .Include(i => i.SecondaryStats)
        //                        .OrderBy(i => i.Name).ToListAsync();
        //}
    }
}
