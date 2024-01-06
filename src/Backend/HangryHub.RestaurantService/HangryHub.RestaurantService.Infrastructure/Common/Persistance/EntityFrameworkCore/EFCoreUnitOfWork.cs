using HangryHub.RestaurantService.Application.Common.Persistance;
using HangryHub.RestaurantService.Domain.Common.Attributes;

namespace HangryHub.RestaurantService.Infrastructure.Common.Persistance.EntityFrameworkCore;

[Register<IUnitOfWork>]
public class EFCoreUnitOfWork : IUnitOfWork
{
    private readonly RestaurantServiceDbContext _context;

    public EFCoreUnitOfWork(RestaurantServiceDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
