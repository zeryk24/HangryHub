using HangryHub.MainService.Domain.RestaurantAggregate;
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
        public Task<IEnumerable<Domain.RestaurantAggregate.Restaurant>> GetWithAllRelatedEntitiesAsync();

        public Task<IEnumerable<Domain.RestaurantAggregate.Restaurant>> GetWithAllRelatedEntitiesAsync(params RestaurantId[] ids);

        public Task<Domain.RestaurantAggregate.Restaurant?> FindByIdWithAllRelatedEntitiesAsync(RestaurantId id);
    }
}
