using HangryHub.RestaurantService.Application.Common.Services;
using HangryHub.RestaurantService.Domain.Common.Attributes;

namespace HangryHub.RestaurantService.Infrastructure.Common.Services;

[Register<IDateTimeProvider>]
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;

    public DateTime UtcNow => DateTime.UtcNow;
}
