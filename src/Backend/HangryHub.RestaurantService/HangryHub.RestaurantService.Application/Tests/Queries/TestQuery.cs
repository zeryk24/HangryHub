using ErrorOr;
using HangryHub.RestaurantService.Application.Common.Attributes;
using MediatR;

namespace HangryHub.RestaurantService.Application.Tests.Queries;

public record TestQuery(string FirstName, string LastName, int Age) : IRequest<ErrorOr<TestQuery.Result>>
{
    public record Result(string FullName, bool IsOver18);
}

[RegisterRequestHandler]
public class TestQueryHandler : IRequestHandler<TestQuery, ErrorOr<TestQuery.Result>>
{
    public Task<ErrorOr<TestQuery.Result>> Handle(TestQuery request, CancellationToken cancellationToken)
    {
        string fullName = request.FirstName + " " + request.LastName;
        bool isOver18 = request.Age > 18;

        var result = new TestQuery.Result(fullName, isOver18);

        return Task.FromResult(ErrorOrFactory.From(result));
    }
}
