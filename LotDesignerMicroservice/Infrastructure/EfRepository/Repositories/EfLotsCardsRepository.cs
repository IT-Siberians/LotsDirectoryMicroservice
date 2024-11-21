using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;
using LotDesignerMicroservice.Infrastructure.EfRepository.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace LotDesignerMicroservice.Infrastructure.EfRepository.Repositories
{
    public class EfLotsCardsRepository(ApplicationDbContext context)
        : EfRepository<LotCard, Guid>(context), ILotsCardsRepository
    {
        private readonly DbSet<LotCard> _lotsCards = context.Set<LotCard>();

        public override async Task<IEnumerable<LotCard>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _lotsCards
                .Include(s => s.Seller)
                .Include(c => c.Images)
                .ToListAsync(cancellationToken);

        public override async Task<LotCard?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _lotsCards
                .Include(s => s.Seller)
                .Include(c => c.Images)
                .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

        public async Task<IEnumerable<LotCard>> GetAllBySellerAsync(Seller seller, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(seller, nameof(seller));

            return await _lotsCards
                .Include(s => s.Seller)
                .Include(c => c.Images)
                .Where(l => l.Seller.Equals(seller))
                .ToListAsync(cancellationToken);
        }
    }
}