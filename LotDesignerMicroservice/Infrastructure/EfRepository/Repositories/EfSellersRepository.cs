using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;
using LotDesignerMicroservice.Domain.ValueObjects.StringObjects;
using LotDesignerMicroservice.Infrastructure.EfRepository.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace LotDesignerMicroservice.Infrastructure.EfRepository.Repositories
{
    public class EfSellersRepository(ApplicationDbContext context)
        : EfRepository<Seller, Guid>(context), ISellersRepository
    {
        private readonly DbSet<Seller> _sellers = context.Set<Seller>();

        public async Task<Seller?> GetByUsernameAsync(string userName, CancellationToken cancellationToken = default)
            => await _sellers.FirstOrDefaultAsync(s => s.UserName.Value.Equals(new UserName(userName)), cancellationToken);
    }
}
