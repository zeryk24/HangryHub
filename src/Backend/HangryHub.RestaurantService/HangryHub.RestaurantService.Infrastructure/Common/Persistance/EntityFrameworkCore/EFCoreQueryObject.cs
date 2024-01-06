using HangryHub.RestaurantService.Application.Common.Persistance;
using HangryHub.RestaurantService.Domain.Common.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HangryHub.RestaurantService.Infrastructure.Common.Persistance.EntityFrameworkCore;

[Register(typeof(IQueryObject<>), ServiceLifetime.Transient)]
public class EFCoreQueryObject<TAggregate> : QueryObject<TAggregate> where TAggregate : class
{
    private readonly RestaurantServiceDbContext _dbContext;

    public EFCoreQueryObject(RestaurantServiceDbContext dbContext)
    {
        _dbContext = dbContext;
        _query = _dbContext.Set<TAggregate>().AsQueryable();
    }

    public override async Task<IEnumerable<TAggregate>> ExecuteAsync()
    {
        return await _query.ToListAsync();
    }
}
