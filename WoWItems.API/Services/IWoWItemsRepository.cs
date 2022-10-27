using WoWItems.API.Entities;
using WoWItems.API.Models;

namespace WoWItems.API.Services
{
    public interface IWoWItemsRepository
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<(IEnumerable<Item>, PaginationMetadata)> GetItemsAsync(string? name, PrimaryStatType? primaryStat, int pageNumber, int pageSize);
        Task<Item?> GetItemAsync(int itemId);
        Task<bool> ItemExistsAsync(int itemId);
        Task<bool> StatExistsAsync(int itemId, SecondaryStatType secondaryStatType);
        Task<bool> StatExistsAsync(int itemId, PrimaryStatType secondaryStatType);
        Task<PrimaryStat?> GetStatAsync(int itemId);
        Task<SecondaryStat?> GetStatAsync(int itemId, SecondaryStatType secondaryStatType);
        Task AddSecondaryStatToItemAsync(int itemId, SecondaryStat secondaryStat);
        Task AddPrimaryStatToItemAsync(int itemId, PrimaryStat primaryStat);
        Task<bool> SaveChangesAsync();
    }
}
