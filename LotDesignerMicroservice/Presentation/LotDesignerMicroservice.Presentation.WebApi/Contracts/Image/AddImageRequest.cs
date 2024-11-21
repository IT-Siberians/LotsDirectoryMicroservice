namespace LotDesignerMicroservice.Presentation.WebApi.Contracts.Image
{
    public record class AddImageRequest(Guid LotCardId, string Url);
}