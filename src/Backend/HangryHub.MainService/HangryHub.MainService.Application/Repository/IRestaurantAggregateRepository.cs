using HangryHub.MainService.Domain.RestaurantAggregate;
using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Repository
{
    public interface IRestaurantAggregateRepository : IRepository<Domain.RestaurantAggregate.Restaurant>
    {
        public Task<IEnumerable<Domain.RestaurantAggregate.Restaurant>> GetAllWithDetailsAsync();

        public Task<IEnumerable<Domain.RestaurantAggregate.Restaurant>> GetWithDetailsAsync(params RestaurantId[] ids);

        public Task<Domain.RestaurantAggregate.Restaurant?> GetWithDetailsAsync(RestaurantId id);

        public Task<IEnumerable<RestaurantItem>> GetrRestaurantItemWithDetailsAsync(params RestaurantItemId[] ids);

        public Task<RestaurantItem?> GetrRestaurantItemWithDetailsAsync(RestaurantItemId id);
    }
}
