using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Base;
using LotDesignerMicroservice.Domain.Entities.Entities;

namespace LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions
{
    public interface IImagesRepository : IRepository<Image, Guid>
    {
        Task<IEnumerable<Image>> GetByLotCardId(Guid lotCardId, CancellationToken cancellationToken);
    }
}
