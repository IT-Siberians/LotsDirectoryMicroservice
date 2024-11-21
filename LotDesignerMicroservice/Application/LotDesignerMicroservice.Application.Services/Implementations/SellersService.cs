using AutoMapper;
using LotDesignerMicroservice.Application.Models.Seller;
using LotDesignerMicroservice.Application.Services.Base;
using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;
using LotDesignerMicroservice.Domain.ValueObjects.StringObjects;

namespace LotDesignerMicroservice.Application.Services.Implementations
{
    public class SellersService(ISellersRepository sellersRepository, IMapper mapper) : ISellersService
    {
        public async Task<Guid?> CreateAsync(CreateSellerModel createSellerModel, CancellationToken cancellationToken)
        {
            if (await sellersRepository.GetByIdAsync(createSellerModel.Id, cancellationToken) is not null)
                return null;

            var newSeller = new Seller(createSellerModel.Id, new UserName(createSellerModel.UserName));
            return await sellersRepository.CreateAsync(newSeller, cancellationToken);
        }

        public async Task<SellerModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var seller = await sellersRepository.GetByIdAsync(id, cancellationToken);
            return seller is null ? null : mapper.Map<SellerModel>(seller);
        }

        public async Task<SellerModel?> GetByUserNameAsync(string userName, CancellationToken cancellationToken)
        {
            var seller = await sellersRepository.GetByUsernameAsync(userName, cancellationToken);
            return seller is null ? null : mapper.Map<SellerModel>(seller);
        }

        public async Task<IEnumerable<SellerModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var sellers = await sellersRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<SellerModel>>(sellers);
        }

        public async Task<bool> UpdateAsync(SellerModel sellerModel, CancellationToken cancellationToken)
        {
            var seller = await sellersRepository.GetByIdAsync(sellerModel.Id, cancellationToken);
            if (seller is null)
                return false;

            var updatedSeller = mapper.Map<Seller>(sellerModel);
            return await sellersRepository.UpdateAsync(updatedSeller, cancellationToken);
        }
    }
}