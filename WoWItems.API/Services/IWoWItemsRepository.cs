using WoWItems.API.Entities;
using WoWItems.API.Models;

namespace WoWItems.API.Services
{
    public interface IWoWItemsRepository
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<IEnumerable<Item>> GetItemsAsync(string? name, PrimaryStatType? primaryStat, SecondaryStatType? secondaryStat, int pageNumber, int pageSize);
        Task<Item?> GetItemAsync(int itemId);
        Task<bool> ItemExistsAsync(int itemId);
        Task<bool> StatExistsAsync(int itemId, SecondaryStatType secondaryStatType);
        Task<bool> StatExistsAsync(int itemId, PrimaryStatType primaryStatType);
        Task<PrimaryStat?> GetStatAsync(int itemId, PrimaryStatType primaryStatType);
        Task<SecondaryStat?> GetStatAsync(int itemId, SecondaryStatType secondaryStatType);
        Task AddSecondaryStatToItemAsync(int itemId, SecondaryStat secondaryStat);
        Task AddPrimaryStatToItemAsync(int itemId, PrimaryStat primaryStat);
        Task AddItemAsync(Item item);
        Task SaveChangesAsync(CancellationToken token);
        Task DeleteItemAsync(Item item);
        Task UpdateStatAsync(PrimaryStat primaryStat);
        Task UpdateStatAsync(SecondaryStat secondaryStat);
    }
}
