using HangryHub.MainService.Contracts.Messages;
using HangryHub.MainService.Contracts.Messages.MessageParts;
using HangryHub.OderService.UseCases.Order.DTOs;
using HangryHub.OrderService.Core.OrderAggregate.Entities.IngredientEntity;
using HangryHub.OrderService.Core.OrderAggregate.Enums;
using HangryHub.OrderService.Core.OrderAggregate.ValueObjects;
using MassTransit;
using MediatR;
using System.Xml.Linq;

namespace HangryHub.OderService.UseCases.Order.Create
{
    public class CreateOrderMessageConsumer : IConsumer<OrderMessage>
    {
        private readonly IMediator mediator;
        public CreateOrderMessageConsumer(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Consume(ConsumeContext<OrderMessage> context)
        {
            var message = context.Message;
            if (message == null)
            {
                return;
            }
            var orderDTO = new OrderDTO()
            {
                Id = message.OrderId,
                PriceEuro = new PriceDTO() { Euro = Decimal.ToDouble(message.Subtotal) },
                OrderState = OrderStatusDTO.NotAccepted,
                Coupon = null,
                UserId = new UserIdDTO() { Id = message.UserId },
                RestaurantId = new RestaurantIdDTO() { Id = message.RestaurantId },
                Items = MapOrderItems(message),
            };
            await mediator.Send(new CreateOrderCommand(orderDTO));
        }

        private List<OrderItemDTO> MapOrderItems(OrderMessage message)
        {
            var result = new List<OrderItemDTO>();

            foreach (var item in message.Items)
            {
                if (item != null)
                {
                    var orderItem = new OrderItemDTO()
                    {
                        RestaurantItemId = new RestaurantItemIdDTO() { ItemId = item.RestaurantItemId },
                        Name = new ItemNameDTO() { Name = item.Name },
                        Quantity = new ItemQuantityDTO() { Quantity = item.Quantity },
                        Price = new ItemPriceDTO() { Price = Decimal.ToDouble(item.Price) },
                        ExtraIngredients = MapExtraIngredients(item.AdditionalIngredients)
                    };
                    result.Add(orderItem);
                }
            }

            return result;
        }

        private List<ExtraIngredientDTO> MapExtraIngredients(List<AdditionalIngredientMessage> message)
        {
            var result = new List<ExtraIngredientDTO>();

            foreach (var item in message)
            {
                var ingredientItem = new ExtraIngredientDTO()
                {
                    Name = new IngredientNameDTO() { Name = item.Name },
                    Quantity = new IngredientQuantityDTO() { Quantity = item.Quantity },
                };
                result.Add(ingredientItem);
            }

            return result;
        }
    }
}
