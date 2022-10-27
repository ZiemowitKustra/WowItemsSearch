using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WoWItems.API.Models;
using WoWItems.API.Services;

namespace WoWItems.API.Controllers
{
    [Route("api/items/{itemId}/primarystats")]
    [ApiController]
    public class PrimaryStatController : Controller
    {
        private readonly IWoWItemsRepository _woWItemsRepository;
        private readonly IMapper _mapper;
        public PrimaryStatController(IWoWItemsRepository woWItemsRepository, IMapper mapper)
        {
            _woWItemsRepository = woWItemsRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPrimaryStat")]
        public ActionResult<IEnumerable<PrimaryStatDto>> GetPrimaryStat(int itemId)
        {
            var item = _woWItemsRepository.GetItemAsync(itemId);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PrimaryStatDto>(item));
        }

        [HttpPost]
        public async Task<ActionResult<PrimaryStatDto?>> AddSecondaryStatToItem(
                int itemId, PrimaryStatCreationDto primaryStat)
        {
            if (!await _woWItemsRepository.ItemExistsAsync(itemId))
            {
                return NotFound();
            }
            if (await _woWItemsRepository.StatExistsAsync(itemId, primaryStat.PrimaryStatType))
            {
                return Conflict();
            }

            var lastPrimaryStat = _mapper.Map<Entities.PrimaryStat>(primaryStat);

            await _woWItemsRepository.AddPrimaryStatToItemAsync(itemId, lastPrimaryStat);

            await _woWItemsRepository.SaveChangesAsync();

            var createdPrimaryStat = _mapper.Map<PrimaryStatDto>(lastPrimaryStat);

            return CreatedAtRoute("GetPrimaryStat",
                new
                {
                    ItemId = itemId,
                    PrimaryStatType = createdPrimaryStat.PrimaryStatType,
                    Value = createdPrimaryStat.Value
                }, lastPrimaryStat); ;
        }
    }
}
