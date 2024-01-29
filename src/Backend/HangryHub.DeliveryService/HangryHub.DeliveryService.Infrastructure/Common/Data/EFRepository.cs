using HangryHub.DeliveryService.Application.Common;

namespace HangryHub.DeliveryService.Infrastructure.Common.Data
{
    class EFRepository<TAggregate> : IRepository<TAggregate> where TAggregate : class
    {
        protected DeliveryServiceContext Context;
        public EFRepository(DeliveryServiceContext context)
        {
            Context = context;
        }   
        public async Task<TAggregate?> GetByIdAsync(object id)
        {
            var result = await Context.Set<TAggregate>().FindAsync(id);

            return result;
        }

        public void Insert(TAggregate entity)
        {
            Context.Set<TAggregate>().Add(entity);
        }

        public async Task<bool> RemoveAsync(object id)
        {
            var entity = await Context.Set<TAggregate>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            Context.Set<TAggregate>().Remove(entity);
            return true;
        }

        public void Update(TAggregate entity)
        {
            Context.Set<TAggregate>().Update(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }   
    }
}
