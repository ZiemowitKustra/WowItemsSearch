using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WoWItems.API.DbContexts;
using WoWItems.API.Entities;
using WoWItems.API.Models;
using WoWItems.API.Models.Stats.PrimaryStat;
using WoWItems.API.Models.Stats.SecondaryStat;
using WoWItems.API.Services;

namespace WoWItems.API.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IWoWItemsRepository _woWItemsRepository;
        private readonly IMapper _mapper;
        const int maxItemsPageSize = 50;

        public ItemsController(IWoWItemsRepository woWItemsRepository,
            IMapper mapper)
        {
            _woWItemsRepository = woWItemsRepository ??
                throw new ArgumentNullException(nameof(woWItemsRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems(
            string? name, int? primaryStat, int? secondaryStat,
            int pageNumber = 1, int pageSize = 10)
        {
            if(pageSize > maxItemsPageSize)
            {
                pageSize = maxItemsPageSize;
            }

            var items = await _woWItemsRepository.GetItemsAsync(
                name, (PrimaryStatType?)primaryStat, (SecondaryStatType?)secondaryStat, pageNumber, pageSize);
            

            return Ok(_mapper.Map<IEnumerable<ItemDto>>(items));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecificItem(int id)
        {
            var item = await _woWItemsRepository.GetItemAsync(id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ItemDto>(item));
        }

        [HttpPost]
        public  async Task<ActionResult> PostNewItem(ItemCreationDto item)
        {
            var _item = _mapper.Map<Item>(item);
            await _woWItemsRepository.AddItemAsync(_item);
            return CreatedAtRoute("GetItem",item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(int id)
        {
            var item = await _woWItemsRepository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            await _woWItemsRepository.DeleteItemAsync(item);
            return NoContent();
        }
    }
}
