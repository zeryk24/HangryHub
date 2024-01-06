using System.Linq.Expressions;

namespace HangryHub.RestaurantService.Application.Common.Persistance;

public interface IQueryObject<TAggregate> where TAggregate : class
{
    IQueryObject<TAggregate> Filter(Expression<Func<TAggregate, bool>> predicate);
    IQueryObject<TAggregate> OrderBy<TKey>(Expression<Func<TAggregate, TKey>> selector, bool ascending = true);
    IQueryObject<TAggregate> Page(int page, int pageSize);

    Task<IEnumerable<TAggregate>> ExecuteAsync();
}