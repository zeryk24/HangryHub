﻿using HangryHub.OrderService.Core.Interfaces;
using Mapster;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.GetById
{
    public class GetOrderByIdHandler(IGetOrderByIdService getOrderByIdService)
                : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {
        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = getOrderByIdService.GetOrderById(request.Id);

            return order.Adapt<OrderDTO>();
        }
    }
}