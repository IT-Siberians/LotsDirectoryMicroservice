using LotDesignerMicroservice.Application.Models.Image;
using LotDesignerMicroservice.Application.Models.LotCard;
using LotDesignerMicroservice.Application.Models.Seller;

namespace LotDesignerMicroservice.Application.Services.Base
{
    public interface ILotsCardsService
    {
        Task<LotCardModel?> CreateAsync(CreateLotCardModel createLotCardModel, CancellationToken cancellationToken);
        Task<LotCardModel?> CopyAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(LotCardModel lotCardModel, CancellationToken cancellationToken);
        Task<LotCardModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<LotCardModel>> GetAllBySellerIdAsync(SellerModel seller, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(UpdateLotCardModel card, CancellationToken cancellationToken);


        Task<bool> AddImageAsync(AddImageModel addImageModel, CancellationToken cancellationToken);
        Task<bool> RemoveImageAsync(RemoveImageModel removeImageModel, CancellationToken cancellationToken);

        Task<bool> TradeAsync(Guid id, CancellationToken cancellationToken);
    }
}
