using AutoMapper;
using LotDesignerMicroservice.Application.Models.Image;
using LotDesignerMicroservice.Application.Services.Base;
using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;

namespace LotDesignerMicroservice.Application.Services.Implementations
{
    public class ImagesService(IImagesRepository imagesRepository, IMapper mapper) : IImagesService
    {
        public async Task<Guid?> CreateAsync(string imageUrl, CancellationToken cancellationToken)
        {
            var newImage = new Image(new Uri(imageUrl));
            return await imagesRepository.CreateAsync(newImage, cancellationToken);
        }

        public async Task<bool> DeleteAsync(ImageModel imageModel, CancellationToken cancellationToken)
        {
            var image = await imagesRepository.GetByIdAsync(imageModel.Id, cancellationToken);
            if (image is null)
                return false;

            var imageForDelete = mapper.Map<Image>(imageModel);
            return await imagesRepository.DeleteAsync(imageForDelete, cancellationToken);
        }

        public async Task<IEnumerable<ImageModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var images = await imagesRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<ImageModel>>(images);
        }

        public async Task<ImageModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var image = await imagesRepository.GetByIdAsync(id, cancellationToken);
            return image is null ? null : mapper.Map<ImageModel>(image);
        }

        public async Task<IEnumerable<ImageModel>> GetByLotCardId(Guid lotCardId, CancellationToken cancellationToken)
        {
            var images = await imagesRepository.GetByLotCardId(lotCardId, cancellationToken);
            return mapper.Map<IEnumerable<ImageModel>>(images);
        }
    }
}