using LotDesignerMicroservice.Domain.Entities.Enums;

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
        IEnumerable<Guid> ImagesIds);
}
