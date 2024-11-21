using LotDesignerMicroservice.Application.Models.Seller;

namespace LotDesignerMicroservice.Application.Services.Base
{
    public interface ISellersService
    {
        Task<Guid?> CreateAsync(CreateSellerModel sellerInformation, CancellationToken cancellationToken);
        Task<SellerModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<SellerModel?> GetByUserNameAsync(string userName, CancellationToken cancellationToken);
        Task<IEnumerable<SellerModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> UpdateAsync(SellerModel seller, CancellationToken cancellationToken);
    }
}