namespace HangryHub.RestaurantService.Application.Common.Persistance;

public interface IUnitOfWork
{
    public Task CommitAsync(CancellationToken cancellationToken);
}
