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
        ISellersService sellersService,
        IMapper mapper) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(LotCardResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<LotCardResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var lotCardModel = await lotsCardsService.GetByIdAsync(id, cancellationToken);

            return lotCardModel is null
                ? NotFound($"Seller with ID = {id} not found!")
                : Ok(mapper.Map<LotCardResponse>(lotCardModel));
        }

        [HttpGet]
        [Route("[action]/{sellerId:guid}")]
        [ProducesResponseType(typeof(IEnumerable<LotCardResponse>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<LotCardResponse>> GetAllBySellerIdAsync(Guid sellerId, CancellationToken cancellationToken)
        {
            var sellerModel = await sellersService.GetByIdAsync(sellerId, cancellationToken);

            if (sellerModel is null)
                return NotFound($"Seller with ID = {sellerId} not found!");

            var lotCardModel = await lotsCardsService.GetAllBySellerIdAsync(sellerModel, cancellationToken);

            return Ok(mapper.Map<IEnumerable<LotCardResponse>>(lotCardModel));
        }

        [HttpPost]
        [ProducesResponseType(typeof(LotCardResponse), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<LotCardResponse>> CreateAsync(
            [FromBody] CreateLotCardRequest createLotCardRequest,
            CancellationToken cancellationToken)
        {
            var createLotCardModel = mapper.Map<CreateLotCardModel>(createLotCardRequest);
            var newLotCardModel = await lotsCardsService.CreateAsync(createLotCardModel, cancellationToken);

            return Created("", mapper.Map<LotCardResponse>(newLotCardModel));
        }

        [HttpPost]
        [Route("[action]/{id:guid}")]
        [ProducesResponseType(typeof(LotCardResponse), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<LotCardResponse>> CopyAsync(Guid id, CancellationToken cancellationToken)
        {
            var copiedLotCardModel = await lotsCardsService.CopyAsync(id, cancellationToken);
            return Created("", mapper.Map<LotCardResponse>(copiedLotCardModel));
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> UpdateAsync(Guid id, [FromBody] UpdateLotCardRequest request, CancellationToken cancellationToken)
        {
            var updateLotCardModel = mapper.Map<UpdateLotCardModel>(request);
            return await lotsCardsService.UpdateAsync(updateLotCardModel, cancellationToken) is true ? NoContent() : BadRequest(false);
        }

        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> AddImageAsync([FromBody] AddImageRequest request, CancellationToken cancellationToken)
        {
            var addImageModel = mapper.Map<AddImageModel>(request);
            return await lotsCardsService.AddImageAsync(addImageModel, cancellationToken) is true ? NoContent() : BadRequest(false);
        }

        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> RemoveImageAsync([FromBody] RemoveImageRequest request, CancellationToken cancellationToken)
        {
            var removeImageModel = mapper.Map<RemoveImageModel>(request);
            return await lotsCardsService.RemoveImageAsync(removeImageModel, cancellationToken) is true ? NoContent() : BadRequest(false);
        }

        [HttpPut]
        [Route("[action]/{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> TradeAsync(Guid id, CancellationToken cancellationToken)
        {
            return await lotsCardsService.TradeAsync(id, cancellationToken) is true ? NoContent() : BadRequest(false);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var lotCardModelForDelete = await lotsCardsService.GetByIdAsync(id, cancellationToken);

            if (lotCardModelForDelete is null)
                return NotFound($"Lot card with ID = {id} not found!");

            return await lotsCardsService.DeleteAsync(lotCardModelForDelete, cancellationToken) is true ? NoContent() : BadRequest(false);
        }
    }
}