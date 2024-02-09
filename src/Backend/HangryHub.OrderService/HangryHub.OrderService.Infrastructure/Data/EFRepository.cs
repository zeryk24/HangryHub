using HangryHub.OrderService.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HangryHub.OrderService.Infrastructure.Data
{
    public class EFRepository<TAggregate> : IRepository<TAggregate> where TAggregate : class
    {
        private readonly DbContext context;
        protected readonly DbSet<TAggregate> aggregateSet;
        protected List<Expression<Func<TAggregate, object>>> Includes = new List<Expression<Func<TAggregate, object>>>();

        public EFRepository(DbContext context)
        {
            this.context = context;
            aggregateSet = context.Set<TAggregate>();
        }
        
        public async Task CreateAsync(TAggregate entity)
        {
            await aggregateSet.AddAsync(entity);
        }

        public virtual async Task<IList<TAggregate>> GetAllAsync()
        {
            //return await aggregateSet.ToListAsync();
            var set = aggregateSet.AsNoTracking();
            foreach (var include in Includes)
            {
                set = set.Include(include);
            }
            return await set.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TAggregate?> GetByIdAsync(object id)
        {
            return await aggregateSet.FindAsync(id);
        }

        public bool Delete(object id)
        {
            TAggregate? aggregateToDelete = aggregateSet.Find(id);
            if (aggregateToDelete != null)
            {
                Delete(aggregateToDelete);
                return true;
            }
            return false;
        }

        public void Delete(TAggregate entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                aggregateSet.Attach(entity);
            }
            aggregateSet.Remove(entity);
        }

        public void Update(TAggregate entity)
        {
            aggregateSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveAsync() => await context.SaveChangesAsync();
    }
}
