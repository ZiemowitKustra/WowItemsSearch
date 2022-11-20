using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.SqlTypes;
using WoWItems.API.DbContexts;
using WoWItems.API.Models.Stats.PrimaryStat;
using WoWItems.API.Models.Stats.SecondaryStat;
using WoWItems.API.Services;

namespace WoWItems.API.Controllers
{
    [Route("api/items/{itemId}/secondarystats")]
    [ApiController]
    public class SecondaryStatController : ControllerBase
    {
        private readonly IWoWItemsRepository _woWItemsRepository;
        private readonly IMapper _mapper;

        public SecondaryStatController(IWoWItemsRepository woWItemsRepository, IMapper mapper)
        {
            _woWItemsRepository = woWItemsRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetSecondaryStats")]
        public async Task<ActionResult<IEnumerable<SecondaryStatDto>>> GetSecondaryStats(int itemId)
        {
            var item = await _woWItemsRepository.GetItemAsync(itemId);
            if(item == null)
            {
                return NotFound();
            }
            var stats = item.SecondaryStats.ToList();
            return Ok(_mapper.Map<IEnumerable<SecondaryStatDto>>(stats));
        }

        [HttpPost]
        public async Task<ActionResult<SecondaryStatDto>> AddSecondaryStatToItem(
            int itemId,
            SecondaryStatCreationDto secondaryStat, CancellationToken token = default)
        {
            if (!await _woWItemsRepository.ItemExistsAsync(itemId))
            {
                return NotFound();
            }
            if(await _woWItemsRepository.StatExistsAsync(itemId, secondaryStat.SecondaryStatType))
            {
                return Conflict();
            }

            var lastSecondaryStat = _mapper.Map<Entities.SecondaryStat>(secondaryStat);

            await _woWItemsRepository.AddSecondaryStatToItemAsync(itemId, lastSecondaryStat);

            await _woWItemsRepository.SaveChangesAsync(token);

            var createdSecondaryStat = _mapper.Map<SecondaryStatDto>(lastSecondaryStat);

            return CreatedAtRoute("GetSecondaryStats",
                new
                {
                    ItemId = itemId,
                    SecondaryStatType = createdSecondaryStat.SecondaryStatType,
                    Value = createdSecondaryStat.Value
                }, lastSecondaryStat);
        }

        [HttpPut]
        public async Task<ActionResult<PrimaryStatDto>> UpdateSecondaryStatToItem(
    int itemId, SecondaryStatUpdateDto secondary)
        {
            if (!await _woWItemsRepository.StatExistsAsync(itemId, secondary.SecondaryStatType))
            {
                return NotFound();
            }

            var currentStat = await _woWItemsRepository.GetStatAsync(itemId, secondary.SecondaryStatType);
            currentStat.Value = secondary.Value;
            await _woWItemsRepository.UpdateStatAsync(currentStat);
            return NoContent();
        }

        [HttpDelete("{statId}")]
        public async Task<ActionResult> DeleteSecondaryStat(int itemId, int statId, CancellationToken token = default)
        {
            var item = await _woWItemsRepository.GetItemAsync(itemId);
            if (item == null)
            {
                return NotFound();
            }
            var secondaryStat = item.SecondaryStats.Where(p => p.Id == statId).FirstOrDefault();
            if (secondaryStat == null)
            {
                return NotFound();
            }
            item.SecondaryStats.Remove(secondaryStat);
            await _woWItemsRepository.SaveChangesAsync(token);
            return NoContent();
        }
    }
}
