﻿using ErrorOr;
using HangryHub.OrderService.Core.Interfaces;
using Mapster;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Decline
{
    public class DeclineOrderHandler(IDeclineOrderService declineOrderService) : IRequestHandler<DeclineOrderCommand, ErrorOr<OrderDTO>>
    {
        public async Task<ErrorOr<OrderDTO>> Handle(DeclineOrderCommand request, CancellationToken cancellationToken)
        {
            var orderResult = await declineOrderService.DeclineOrderAsync(request.Id);
            if (orderResult.IsError)
            {
                return orderResult.Errors;
            }
            var order = orderResult.Value;
            return order.Adapt<OrderDTO>();
        }
    }
}