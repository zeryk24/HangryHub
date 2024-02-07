using HangryHub.MainService.Application.Repository;
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
                .Include(a => a.SelectedDeliveryData);
        }
    }
}
