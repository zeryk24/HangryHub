using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Infrastructure.Repository;

namespace HangryHub.MainService.Infrastructure.Repository
{
    public class EFRepository<TAggregate> : IRepository<TAggregate> where TAggregate : class
    {
        protected readonly MainDBContext Context;

        public EFRepository(MainDBContext context)
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

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
