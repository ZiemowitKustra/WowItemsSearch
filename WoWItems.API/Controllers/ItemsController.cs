using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WoWItems.API.Models;
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
            ////////////////
            //searching for SecondaryStats doesnt work
            ////////////////
            //var items = await _woWItemsRepository
            //    .GetItemsAsync(name, primaryStat, secondaryStat, int pageNumber, int pageSize);
            var (items, paginationMetadata) = await _woWItemsRepository
                  .GetItemsAsync(name, (PrimaryStatType?)primaryStat, 
                                 pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

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
    }
}
