using AutoMapper;
using LotDesignerMicroservice.Application.Models.LotCard;
using LotDesignerMicroservice.Application.Models.Image;
using LotDesignerMicroservice.Application.Services.Base;
using LotDesignerMicroservice.Presentation.WebApi.Contracts.Image;
using LotDesignerMicroservice.Presentation.WebApi.Contracts.LotCard;
using Microsoft.AspNetCore.Mvc;

namespace LotDesignerMicroservice.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotsCardsController(
        ILotsCardsService lotsCardsService,
        IMapper mapper) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(LotCardResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<LotCardResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var lotCardModel = await lotsCardsService.GetByIdAsync(id, cancellationToken);

            return lotCardModel is null
                ? NotFound($"Lot card with ID = {id} not found!")
                : Ok(mapper.Map<LotCardResponse>(lotCardModel));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LotCardResponse>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<LotCardResponse>> GetAllAsync(CancellationToken cancellationToken)
        {
            var lotsCardsModels = await lotsCardsService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<LotCardResponse>>(lotsCardsModels));
        }

        [HttpGet]
        [Route("[action]/{sellerId:guid}")]
        [ProducesResponseType(typeof(IEnumerable<LotCardResponse>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<LotCardResponse>> GetAllBySellerIdAsync(Guid sellerId, CancellationToken cancellationToken)
        {
            var lotsCardsModels = await lotsCardsService.GetAllBySellerIdAsync(sellerId, cancellationToken);
            return Ok(mapper.Map<IEnumerable<LotCardResponse>>(lotsCardsModels));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<Guid>> CreateAsync(
            [FromBody] CreateLotCardRequest createLotCardRequest,
            CancellationToken cancellationToken)
        {
            var createdLotCardId = await lotsCardsService
                .CreateAsync(mapper.Map<CreateLotCardModel>(createLotCardRequest), cancellationToken);

            return createdLotCardId is null
                ? BadRequest("Lot card is not created!")
                : Created("", createdLotCardId);
        }

        [HttpPost]
        [Route("[action]/{id:guid}")]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<Guid>> CopyAsync(Guid id, CancellationToken cancellationToken)
        {
            var copiedLotCardId = await lotsCardsService.CopyAsync(id, cancellationToken);

            return copiedLotCardId is null
                ? BadRequest("Lot card is not copied!")
                : Created("", copiedLotCardId);
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> UpdateAsync([FromBody] UpdateLotCardRequest request, CancellationToken cancellationToken)
        {
            var updateLotCardModel = mapper.Map<UpdateLotCardModel>(request);
            return await lotsCardsService.UpdateAsync(updateLotCardModel, cancellationToken) is true
                ? NoContent()
                : BadRequest(false);
        }

        [HttpPut]
        [Route("[action]/")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> AddImageAsync([FromBody] AddImageRequest request, CancellationToken cancellationToken)
        {
            var addImageModel = mapper.Map<AddImageModel>(request);
            return await lotsCardsService.AddImageAsync(addImageModel, cancellationToken) is true
                ? NoContent()
                : BadRequest(false);
        }

        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> RemoveImageAsync([FromBody] RemoveImageRequest request, CancellationToken cancellationToken)
        {
            var removeImageModel = mapper.Map<RemoveImageModel>(request);
            return await lotsCardsService.RemoveImageAsync(removeImageModel, cancellationToken) is true
                ? NoContent()
                : BadRequest(false);
        }

        [HttpPut]
        [Route("[action]/{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> TradeAsync(Guid id, CancellationToken cancellationToken)
        {
            return await lotsCardsService.TradeAsync(id, cancellationToken) is true
                ? NoContent()
                : BadRequest(false);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 404)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return await lotsCardsService.DeleteAsync(id, cancellationToken) is true
                ? NoContent()
                : BadRequest(false);
        }
    }
}