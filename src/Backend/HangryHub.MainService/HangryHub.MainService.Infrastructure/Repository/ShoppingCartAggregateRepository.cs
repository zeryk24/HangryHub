using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Domain.ShoppingCartAggregate;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Infrastructure.Repository
{
    public class ShoppingCartAggregateRepository : EFRepository<ShoppingCart>, IShoppingCartAggregateRepository
    {
        public ShoppingCartAggregateRepository(MainDBContext context) : base(context)
        {
        }

        // GetOrCreate to make this method a bit more useful ...
        // I know it is against CQRS ... but I do not with to make 50 calls.
        public async Task<ShoppingCart?> GetActiveCartForUser(CustomerId customerId, RestaurantId restaurantId)
        {
            var userCart = await GetBaseQuery()
                .OrderBy(a => a.LastUpdatedDate)
                .LastOrDefaultAsync(a => a.CustomerId == customerId && a.RestaurantId == restaurantId);

            return userCart;
        }

        public async Task<ShoppingCart?> CreateActiveCartForUser(CustomerId customerId, RestaurantId restaurantId)
        {
            var cart = new ShoppingCart(new(Guid.NewGuid()))
            {
                CustomerId = customerId,
                RestaurantId = restaurantId,
                LastUpdatedDate = DateTime.Now,
            };

            Context.Add(cart);
            await Context.SaveChangesAsync();

            return cart;
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllWithDetailsAsync()
        {
            return await GetBaseQuery()
                .ToListAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> GetWithDetailsAsync(params ShoppingCartId[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return await GetAllWithDetailsAsync();
            }

            return await GetBaseQuery()
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();
        }

        public async Task<ShoppingCart?> GetWithDetailsAsync(ShoppingCartId id)
        {
            return await GetBaseQuery()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        private IQueryable<ShoppingCart> GetBaseQuery()
        {
            return Context.ShoppingCarts
                .Include(a => a.Items)
                .ThenInclude(item => item.SelectedAdditionalIngredients)
                .Include(a => a.SelectedDeliveryData)
                .Where(a => a.IsActive);
        }
    }
}
