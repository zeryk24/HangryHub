using ErrorOr;
using HangryHub.RestaurantService.Application.Common.Attributes;
using HangryHub.RestaurantService.Application.Common.Persistance;
using HangryHub.RestaurantService.Application.Common.Pipelines;
using MediatR;
using System.Transactions;

namespace HangryHub.RestaurantService.Application.Common.Behaviors;

[RegisterOpenBehavior(typeof(UnitOfWorkBehavior<,>))]
public class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, IUnitOfWorkPipeline 
    where TResponse : IErrorOr
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        using var transactionScope = new TransactionScope();
        var response = await next();

        if (response.IsError)
            return response;

        await _unitOfWork.CommitAsync(cancellationToken);

        transactionScope.Complete();

        return response;
    }
}
