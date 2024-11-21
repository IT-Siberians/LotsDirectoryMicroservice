using AutoMapper;
using LotDesignerMicroservice.Application.Services.Base;
using LotDesignerMicroservice.Presentation.WebApi.Contracts.Image;
using Microsoft.AspNetCore.Mvc;

namespace LotDesignerMicroservice.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController(IImagesService imagesService, IMapper mapper) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ImageResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<ImageResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var imageModel = await imagesService.GetByIdAsync(id, cancellationToken);

            return imageModel is null
                ? NotFound($"Image with ID = {id} not found!")
                : Ok(mapper.Map<ImageResponse>(imageModel));
        }

        [HttpGet]
        [Route("api/[controller]/GetByLotCardId/{lotCardId:guid}")]
        [ProducesResponseType(typeof(IEnumerable<ImageResponse>), 200)]
        public async Task<ActionResult<List<ImageResponse>>> GetByLotCardIdAsync(Guid lotCardId, CancellationToken cancellationToken)
        {
            var imagesModels = await imagesService.GetByLotCardId(lotCardId, cancellationToken);

            return Ok(mapper.Map<IEnumerable<ImageResponse>>(imagesModels));
        }
    }
}