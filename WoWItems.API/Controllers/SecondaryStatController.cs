using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using WoWItems.API.Models;
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
        public ActionResult<IEnumerable<SecondaryStatDto>> GetSecondaryStats(int itemId)
        {
            var item = _woWItemsRepository.GetItemAsync(itemId);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SecondaryStatDto>(item));
        }

        [HttpPost]
        public async Task<ActionResult<SecondaryStatDto?>> AddSecondaryStatToItem(
            int itemId,
            SecondaryStatCreationDto secondaryStat)
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

            await _woWItemsRepository.SaveChangesAsync();

            var createdSecondaryStat = _mapper.Map<SecondaryStatDto>(lastSecondaryStat);

            return CreatedAtRoute("GetSecondaryStats",
                new
                {
                    ItemId = itemId,
                    SecondaryStatType = createdSecondaryStat.SecondaryStatType,
                    Value = createdSecondaryStat.Value
                }, lastSecondaryStat);
        }
    }
}
