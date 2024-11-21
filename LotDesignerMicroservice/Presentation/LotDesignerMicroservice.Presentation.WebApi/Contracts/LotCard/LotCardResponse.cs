using LotDesignerMicroservice.Domain.Entities.Enums;
using LotDesignerMicroservice.Presentation.WebApi.Contracts.Image;

namespace LotDesignerMicroservice.Presentation.WebApi.Contracts.LotCard
{
    public record class LotCardResponse(
        Guid Id,
        string Title,
        string Description,
        decimal StartingPrice,
        decimal PriceStep,
        decimal? RepurchasePrice,
        TimeSpan TradeDuration,
        DateTime CreationDateTime,
        DateTime? LastModifiedDateTime,
        LotCardState State,
        Guid SellerId,
        IEnumerable<ImageResponse> Images);
}