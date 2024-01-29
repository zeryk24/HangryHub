namespace HangryHub.OrderService.Core.Interfaces
{
    public interface IRepository<TAggregate> where TAggregate : class
    {
        Task CreateAsync(TAggregate entity);
        Task<TAggregate?> GetByIdAsync(object id);
        Task<IList<TAggregate>> GetAllAsync();
        void Update(TAggregate entity);
        void Delete(TAggregate entity);
        bool Delete(object id);
        Task SaveAsync();
    }
}
