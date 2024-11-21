using LotDesignerMicroservice.Application.Models.Image;
using LotDesignerMicroservice.Application.Models.LotCard;

namespace LotDesignerMicroservice.Application.Services.Base
{
    public interface ILotsCardsService
    {
        Task<Guid?> CreateAsync(CreateLotCardModel createLotCardModel, CancellationToken cancellationToken);
        Task<Guid?> CopyAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<LotCardModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<LotCardModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<LotCardModel>?> GetAllBySellerIdAsync(Guid sellerId, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(UpdateLotCardModel card, CancellationToken cancellationToken);


        Task<bool> AddImageAsync(AddImageModel addImageModel, CancellationToken cancellationToken);
        Task<bool> RemoveImageAsync(RemoveImageModel removeImageModel, CancellationToken cancellationToken);

        Task<bool> TradeAsync(Guid id, CancellationToken cancellationToken);
    }
}
