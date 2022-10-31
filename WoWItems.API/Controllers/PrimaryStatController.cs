using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WoWItems.API.DbContexts;
using WoWItems.API.Entities;
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
        public async Task<ActionResult<PrimaryStatDto>> AddPrimaryStatToItem(
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

        [HttpPut]
        public async Task<ActionResult<PrimaryStatDto>> UpdatePrimaryStatToItem(
            int itemId, PrimaryStatUpdateDto primary)
        {

            if (!await _woWItemsRepository.StatExistsAsync(itemId, primary.PrimaryStatType))
            {
                return NotFound();
            }

            var currentStat = _woWItemsRepository.GetStatAsync(itemId, primary.PrimaryStatType).Result;
            currentStat.Value = primary.Value;
            _woWItemsRepository.UpdateStat(currentStat);
            return NoContent();
        }

        [HttpDelete("{statId}")]
        public ActionResult DeletePrimaryStat(int itemId, int statId)
        {
            var item = _woWItemsRepository.GetItemAsync(itemId).Result;
            if(item == null)
            {
                return NotFound();
            }
            var primaryStat = item.PrimaryStat.Where(p => p.Id == statId).FirstOrDefault();
            if(primaryStat == null)
            {
                return NotFound();
            }
            item.PrimaryStat.Remove(primaryStat);
            return NoContent();
        }

    }
}
