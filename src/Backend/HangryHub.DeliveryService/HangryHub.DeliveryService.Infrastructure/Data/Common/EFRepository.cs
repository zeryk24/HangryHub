

using HangryHub.DeliveryService.Application.Common;

namespace HangryHub.DeliveryService.Infrastructure.Data.Common
{
    class EFRepository<TAggregate> : IRepository<TAggregate> where TAggregate : class
    {
        public Task<TAggregate?> GetByIdAsync(object id)
        {
            return Task.FromResult<TAggregate?>(null);
        }

        public void Insert(TAggregate entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(TAggregate entity)
        {
            throw new NotImplementedException();
        }
    }
}
