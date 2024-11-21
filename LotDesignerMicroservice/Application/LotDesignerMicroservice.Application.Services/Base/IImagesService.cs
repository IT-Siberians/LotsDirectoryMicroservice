using LotDesignerMicroservice.Application.Models.Image;

namespace LotDesignerMicroservice.Application.Services.Base
{
    public interface IImagesService
    {
        Task<Guid?> CreateAsync(string imageUrl, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(ImageModel seller, CancellationToken cancellationToken);
        Task<IEnumerable<ImageModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<ImageModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<ImageModel>> GetByLotCardId(Guid lotCardId, CancellationToken cancellationToken);
    }
}