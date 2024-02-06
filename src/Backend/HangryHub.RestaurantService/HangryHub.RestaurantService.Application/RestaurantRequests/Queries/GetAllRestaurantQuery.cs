using ErrorOr;
using HangryHub.RestaurantService.Application.Common.Persistance;
using HangryHub.RestaurantService.Application.RestaurantRequests.Models;
using HangryHub.RestaurantService.Domain.RestaurantAggregate;
using MediatR;

namespace HangryHub.RestaurantService.Application.RestaurantRequests.Queries;

public record GetAllRestaurantQuery(int PageNumber, int PageSize) : IRequest<ErrorOr<GetAllRestaurantQuery.Result>>
{
    public record Result(IEnumerable<RestaurantIdModel> Restaurants);
}

public class GetAllRestaurantQueryHandler : IRequestHandler<GetAllRestaurantQuery, ErrorOr<GetAllRestaurantQuery.Result>>
{
    private readonly IQueryObject<Restaurant> _queryObject;

    public GetAllRestaurantQueryHandler(IQueryObject<Restaurant> queryObject)
    {
        _queryObject = queryObject;
    }

    public async Task<ErrorOr<GetAllRestaurantQuery.Result>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
    {
        var restaurants = await _queryObject.Page(request.PageNumber, request.PageSize).ExecuteAsync();

        return new GetAllRestaurantQuery.Result(restaurants.Select(RestaurantMapper.MapRestaurantToModel));
    }
}
