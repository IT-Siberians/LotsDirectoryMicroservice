namespace LotDesignerMicroservice.Application.Models.LotCard
{
    public record class CreateLotCardModel(
        string Title,
        string Description,
        decimal StartingPrice,
        decimal PriceStep,
        decimal? RepurchasePrice,
        int TradeDurationInHours,
        Guid SellerId,
        IEnumerable<string> ImagesUrls);
}