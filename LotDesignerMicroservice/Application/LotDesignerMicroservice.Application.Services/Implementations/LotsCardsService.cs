using AutoMapper;
using LotDesignerMicroservice.Application.Models.LotCard;
using LotDesignerMicroservice.Application.Models.Image;
using LotDesignerMicroservice.Application.Services.Base;
using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.Entities.Enums;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;
using LotDesignerMicroservice.Domain.ValueObjects.StringObjects;
using LotDesignerMicroservice.Domain.ValueObjects.NumericObjects;
using LotDesignerMicroservice.Domain.ValueObjects.DateTimeObjects;

namespace LotDesignerMicroservice.Application.Services.Implementations
{
    public class LotsCardsService(
        ILotsCardsRepository lotsCardsRepository,
        ISellersRepository sellersRepository,
        IImagesRepository imagesRepository,
        IMapper mapper) : ILotsCardsService
    {
        public async Task<bool> AddImageAsync(AddImageModel addImageModel, CancellationToken cancellationToken)
        {
            var lotCard = await lotsCardsRepository.GetByIdAsync(addImageModel.LotCardId, cancellationToken);
            if (lotCard is null)
                return false;

            var newImage = new Image(new Uri(addImageModel.Url));
            lotCard.AddImages(new List<Image>() { newImage });

            return await lotsCardsRepository.UpdateAsync(lotCard, cancellationToken);
        }

        public async Task<Guid?> CopyAsync(Guid id, CancellationToken cancellationToken)
        {
            var originalLotCard = await lotsCardsRepository.GetByIdAsync(id, cancellationToken);
            if (originalLotCard is null)
                return null;

            var copiedLotCard = new LotCard(
                originalLotCard.Title,
                originalLotCard.Description,
                originalLotCard.StartingPrice,
                originalLotCard.PriceStep,
                originalLotCard.RepurchasePrice,
                originalLotCard.TradeDuration,
                originalLotCard.Seller,
                originalLotCard.Images);

            return await lotsCardsRepository.CreateAsync(copiedLotCard, cancellationToken);
        }

        public async Task<Guid?> CreateAsync(CreateLotCardModel createLotCardModel, CancellationToken cancellationToken)
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
                seller,
                createLotCardModel.ImagesUrls.Select(url => new Image(new Uri(url))));

            return await lotsCardsRepository.CreateAsync(newLotCard, cancellationToken);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var lotCard = await lotsCardsRepository.GetByIdAsync(id, cancellationToken);
            if (lotCard is null)
                return false;

            lotCard.SetState(LotCardState.Removed);
            return await lotsCardsRepository.UpdateAsync(lotCard, cancellationToken);
        }

        public async Task<IEnumerable<LotCardModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var lotsCards = await lotsCardsRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<LotCardModel>>(lotsCards);
        }

        public async Task<IEnumerable<LotCardModel>?> GetAllBySellerIdAsync(Guid sellerId, CancellationToken cancellationToken)
        {
            var seller = await sellersRepository.GetByIdAsync(sellerId, cancellationToken);
            if (seller is null)
                return null;

            var lotsCards = await lotsCardsRepository.GetAllBySellerAsync(seller, cancellationToken);
            return mapper.Map<IEnumerable<LotCardModel>>(lotsCards);
        }

        public async Task<LotCardModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var lotCard = await lotsCardsRepository.GetByIdAsync(id, cancellationToken);
            return lotCard is null ? null : mapper.Map<LotCardModel>(lotCard);
        }

        public async Task<bool> RemoveImageAsync(RemoveImageModel removeImageModel, CancellationToken cancellationToken)
        {
            var lotCard = await lotsCardsRepository.GetByIdAsync(removeImageModel.LotCardId, cancellationToken);
            if (lotCard is null)
                return false;

            var image = await imagesRepository.GetByIdAsync(removeImageModel.ImageId, cancellationToken);
            if (image is null)
                return false;

            lotCard.RemoveImages(new List<Image>() { image });

            return await lotsCardsRepository.UpdateAsync(lotCard, cancellationToken);
        }

        public async Task<bool> TradeAsync(Guid id, CancellationToken cancellationToken)
        {
            var lotCard = await lotsCardsRepository.GetByIdAsync(id, cancellationToken);
            if (lotCard is null)
                return false;

            lotCard.SetState(LotCardState.Active);
            throw new NotImplementedException();
            return await lotsCardsRepository.UpdateAsync(lotCard, cancellationToken);
        }

        public async Task<bool> UpdateAsync(UpdateLotCardModel updateLotCardModel, CancellationToken cancellationToken)
        {
            var lotCard = await lotsCardsRepository.GetByIdAsync(updateLotCardModel.id, cancellationToken);
            if (lotCard is null)
                return false;

            if (lotCard.Title != new Title(updateLotCardModel.Title))
                lotCard.SetTitle(new Title(updateLotCardModel.Title));

            if (!lotCard.Description.Equals(new Text(updateLotCardModel.Description)))
                lotCard.SetDescription(new Text(updateLotCardModel.Description));

            if (!lotCard.StartingPrice.Equals(new Price(updateLotCardModel.StartingPrice)))
                lotCard.SetStartingPrice(new Price(updateLotCardModel.StartingPrice));

            if (!lotCard.PriceStep.Equals(new Price(updateLotCardModel.PriceStep)))
                lotCard.SetPriceStep(new Price(updateLotCardModel.PriceStep));

            if (updateLotCardModel.RepurchasePrice is null && lotCard.RepurchasePrice is not null)
                lotCard.ClearRepurchasePrice();
            else if (updateLotCardModel.RepurchasePrice.HasValue
                && !new Price(updateLotCardModel.RepurchasePrice.Value).Equals(lotCard.RepurchasePrice))
                lotCard.SetRepurchasePrice(new Price(updateLotCardModel.RepurchasePrice.Value));

            if (!lotCard.TradeDuration.Equals(new TradeDuration(new TimeSpan(updateLotCardModel.TradeDurationInHours, 0, 0))))
                lotCard.SetTradeDuration(new TradeDuration(new TimeSpan(updateLotCardModel.TradeDurationInHours, 0, 0)));

            var imagesForRemoving = lotCard.Images
                .Where(i => !updateLotCardModel.ImagesUrls.Contains(i.Url.ToString()));
            if (imagesForRemoving.Any())
                lotCard.RemoveImages(imagesForRemoving);

            var imagesForAdding = updateLotCardModel.ImagesUrls
                .Where(u => !lotCard.Images.Any(i => i.Url.Equals(new Uri(u))));
            if (imagesForAdding.Any())
                lotCard.AddImages(imagesForAdding.Select(x => new Image(new Uri(x))));

            return await lotsCardsRepository.UpdateAsync(lotCard, cancellationToken);
        }
    }
}