using Microsoft.EntityFrameworkCore;

namespace HangryHub.OrderService.Infrastructure.Data.Order
{
    public class OrderRepository : EFRepository<Core.OrderAggregate.Order>
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }

        public override async Task<IList<Core.OrderAggregate.Order>> GetAllAsync()
        {
            var set = aggregateSet.AsNoTracking();
            set = set.Include(o => o.Coupon);
            set = set.Include(o => o.Items).ThenInclude(i => i.ExtraIngredients);
            return await set.ToListAsync();
        }

        public override async Task<Core.OrderAggregate.Order?> GetByIdAsync(object id)
        {
            Guid guid = (Guid)id;
            
            var set = aggregateSet.AsNoTracking();
            set = set.Include(o => o.Coupon);
            set = set.Include(o => o.Items).ThenInclude(i => i.ExtraIngredients);

            return await set.FirstOrDefaultAsync(o => o.Id == guid);
        }
    }
}
