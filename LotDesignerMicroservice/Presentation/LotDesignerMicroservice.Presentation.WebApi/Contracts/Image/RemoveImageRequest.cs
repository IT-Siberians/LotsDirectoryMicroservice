namespace LotDesignerMicroservice.Presentation.WebApi.Contracts.Image
{
    public record class RemoveImageRequest(Guid LotCardId, Guid ImageId);
}