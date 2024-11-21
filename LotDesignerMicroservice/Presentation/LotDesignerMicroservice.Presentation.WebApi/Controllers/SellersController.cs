using AutoMapper;
using LotDesignerMicroservice.Application.Models.LotCard;
using LotDesignerMicroservice.Application.Models.Seller;
using LotDesignerMicroservice.Application.Services.Base;
using LotDesignerMicroservice.Application.Services.Implementations;
using LotDesignerMicroservice.Presentation.WebApi.Contracts.LotCard;
using LotDesignerMicroservice.Presentation.WebApi.Contracts.Seller;
using Microsoft.AspNetCore.Mvc;

namespace LotDesignerMicroservice.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellersController(ISellersService sellersService, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateSellerRequest createSellerRequest, CancellationToken cancellationToken)
        {
            var createdSellerModel = await sellersService
                .CreateAsync(mapper.Map<CreateSellerModel>(createSellerRequest), cancellationToken);

            return createdSellerModel is null
                ? BadRequest("Lot card is not created!")
                : Created("", createdSellerModel);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(SellerResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<SellerResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var sellerModel = await sellersService.GetByIdAsync(id, cancellationToken);

            return sellerModel is null
                ? NotFound($"Seller with ID = {id} not found!")
                : Ok(mapper.Map<SellerResponse>(sellerModel));
        }

        [HttpGet("{userName}")]
        [ProducesResponseType(typeof(SellerResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<SellerResponse>> GetByUserNameAsync(string userName, CancellationToken cancellationToken)
        {
            var sellerModel = await sellersService.GetByUserNameAsync(userName, cancellationToken);

            return sellerModel is null
                ? NotFound($"Seller with UserName = {userName} not found!")
                : Ok(mapper.Map<SellerResponse>(sellerModel));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SellerResponse>), 200)]
        public async Task<ActionResult<List<SellerResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var sellersModels = await sellersService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<SellerResponse>>(sellersModels));
        }
    }
}