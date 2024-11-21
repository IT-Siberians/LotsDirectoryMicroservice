namespace LotDesignerMicroservice.Presentation.WebApi.Contracts.LotCard
{
    public record class UpdateLotCardRequest(
        Guid id,
        string Title,
        string Description,
        decimal StartingPrice,
        decimal PriceStep,
        decimal? RepurchasePrice,
        int TradeDurationInHours,
        IEnumerable<string> ImagesUrls);
}