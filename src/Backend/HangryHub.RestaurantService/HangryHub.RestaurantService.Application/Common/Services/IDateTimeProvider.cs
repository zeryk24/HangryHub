namespace HangryHub.RestaurantService.Application.Common.Services;

public interface IDateTimeProvider
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}
