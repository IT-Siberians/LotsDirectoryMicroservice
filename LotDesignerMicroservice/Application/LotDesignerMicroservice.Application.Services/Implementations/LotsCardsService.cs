using AutoMapper;
using LotDesignerMicroservice.Application.Models.LotCard;
using LotDesignerMicroservice.Application.Models.Seller;
using LotDesignerMicroservice.Application.Services.Base;
using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.Entities.Enums;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;
using LotDesignerMicroservice.Domain.ValueObjects.StringObjects;
using LotDesignerMicroservice.Domain.ValueObjects.NumericObjects;
using LotDesignerMicroservice.Domain.ValueObjects.DateTimeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotDesignerMicroservice.Application.Models.Image;

namespace LotDesignerMicroservice.Application.Services.Implementations
{
    public class LotsCardsService(
        ILotsCardsRepository lotsCardsRepository,
        ISellersRepository sellersRepository,
        IImagesService imagesService,
        IMapper mapper) : ILotsCardsService
    {
        public Task<bool> AddImageAsync(AddImageModel addImageModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<LotCardModel?> CopyAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<LotCardModel?> CreateAsync(CreateLotCardModel createLotCardModel, CancellationToken cancellationToken)
        {
            var seller = await sellersRepository.GetByIdAsync(createLotCardModel.SellerId, cancellationToken);
            if (seller is null)
                return null;

            var newLotCard = new LotCard(
                new Title(createLotCardModel.Title),
                new Text(createLotCardModel.Description),
                new Price(createLotCardModel.StartingPrice),
                new Price(createLotCardModel.PriceStep),
                createLotCardModel.RepurchasePrice.HasValue
                    ? new Price(createLotCardModel.RepurchasePrice.Value)
                    : null,
                new TradeDuration(new TimeSpan(createLotCardModel.TradeDurationInHours, 0, 0)),
                LotCardState.Created,
                seller);

            return await lotsCardsRepository.CreateAsync(newLotCard, cancellationToken)
                ? mapper.Map<LotCardModel>(newLotCard)
                : null;
        }

        public Task<bool> DeleteAsync(LotCardModel lotCardModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LotCardModel>> GetAllBySellerIdAsync(SellerModel seller, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<LotCardModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveImageAsync(RemoveImageModel removeImageModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TradeAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(UpdateLotCardModel card, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public async Task<SellerModel?> CreateAsync(CreateSellerModel createSellerModel, CancellationToken cancellationToken)
        //{
        //    if (await sellersRepository.GetByIdAsync(createSellerModel.Id, cancellationToken) is not null)
        //        return null;

        //    var newSeller = new Seller(createSellerModel.Id, new UserName(createSellerModel.UserName));
        //    return await sellersRepository.CreateAsync(newSeller, cancellationToken)
        //        ? mapper.Map<SellerModel>(newSeller) : null;
        //}

        //public async Task<SellerModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        //{
        //    var seller = await sellersRepository.GetByIdAsync(id, cancellationToken);
        //    return seller is null ? null : mapper.Map<SellerModel>(seller);
        //}

        //public async Task<SellerModel?> GetByUserNameAsync(string userName, CancellationToken cancellationToken)
        //{
        //    var seller = await sellersRepository.GetByUsernameAsync(userName, cancellationToken);
        //    return seller is null ? null : mapper.Map<SellerModel>(seller);
        //}

        //public async Task<IEnumerable<SellerModel>> GetAllAsync(CancellationToken cancellationToken)
        //{
        //    var sellers = await sellersRepository.GetAllAsync(cancellationToken);
        //    return mapper.Map<IEnumerable<SellerModel>>(sellers);
        //}

        //public async Task<bool> UpdateAsync(SellerModel sellerModel, CancellationToken cancellationToken)
        //{
        //    var seller = await sellersRepository.GetByIdAsync(sellerModel.Id, cancellationToken);
        //    if (seller is null)
        //        return false;

        //    var updatedSeller = mapper.Map<Seller>(sellerModel);
        //    return await sellersRepository.UpdateAsync(updatedSeller, cancellationToken);
        //}

    }
}
