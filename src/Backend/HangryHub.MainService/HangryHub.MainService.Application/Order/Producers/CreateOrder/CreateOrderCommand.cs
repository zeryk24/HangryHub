using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Order.Producers.CreateOrder
{
    public class CreateOrderCommand : IRequest
    {
        public required Guid ShoppingCartId { get; set; }
    }
}
