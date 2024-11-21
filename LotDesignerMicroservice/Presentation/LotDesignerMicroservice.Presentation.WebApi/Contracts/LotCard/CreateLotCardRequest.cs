namespace LotDesignerMicroservice.Presentation.WebApi.Contracts.LotCard
{
    public record class CreateLotCardRequest(
        string Title,
        string Description,
        decimal StartingPrice,
        decimal PriceStep,
        decimal? RepurchasePrice,
        int TradeDurationInHours,
        Guid SellerId,
        List<string> ImagesUrls);
}