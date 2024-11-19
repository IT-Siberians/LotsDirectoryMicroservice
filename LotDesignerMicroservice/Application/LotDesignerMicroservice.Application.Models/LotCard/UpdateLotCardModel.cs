namespace LotDesignerMicroservice.Application.Models.LotCard
{
    public record class UpdateLotCardModel(
        string Title,
        string Description,
        decimal StartingPrice,
        decimal PriceStep,
        decimal? RepurchasePrice,
        int TradeDurationInHours,
        IEnumerable<string> ImagesUrls);
}