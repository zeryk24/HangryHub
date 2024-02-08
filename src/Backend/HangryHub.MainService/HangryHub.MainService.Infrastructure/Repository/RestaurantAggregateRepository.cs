using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Domain.RestaurantAggregate;
using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Infrastructure.Repository
{
    // TODO -> pass Tasks up unless necessary to await.
    public class RestaurantAggregateRepository : EFRepository<Restaurant>, IRestaurantAggregateRepository
    {
        public RestaurantAggregateRepository(MainDBContext dbContext) : base(dbContext) { }

        public async Task<Restaurant?> GetWithDetailsAsync(RestaurantId id)
        {
            var result = await GetBaseQuery()
                .Where(a => a.Id ==  id)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Restaurant>> GetAllWithDetailsAsync()
        {
            return await GetBaseQuery().ToListAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetWithDetailsAsync(params RestaurantId[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return await GetAllWithDetailsAsync();
            }

            var result = await GetBaseQuery()
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();

            return result;
        }

        private IQueryable<Restaurant> GetBaseQuery()
        {
            return Context.Restaurants
                .Include(a => a.Items)
                .ThenInclude(item => item.Ingredients)
                .Include(a => a.Items)
                .ThenInclude(item => item.AdditionalIngredients)
                .Include(a => a.AvailableCoupons);
        }

        public async Task<IEnumerable<RestaurantItem>> GetrRestaurantItemWithDetailsAsync(params RestaurantItemId[] ids)
        {
            return await Context.RestaurantItems
                .Include(item => item.Ingredients)
                .Include(item => item.AdditionalIngredients)
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();
        }

        public async Task<RestaurantItem?> GetrRestaurantItemWithDetailsAsync(RestaurantItemId id)
        {
            return await Context.RestaurantItems
                .Include(item => item.Ingredients)
                .Include(item => item.AdditionalIngredients)
                .FirstOrDefaultAsync(a => id == a.Id);
        }
    }
}
