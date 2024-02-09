using HangryHub.OderService.UseCases.Order.DTOs;
using HangryHub.OrderService.Core.Interfaces;
using Mapster;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Create
{
    public class CreateOrderHandler(ICreateOrderService createOrderService) : IRequestHandler<CreateOrderCommand, OrderDTO>
    {
        public async Task<OrderDTO> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await createOrderService.CreateOrderAsync(MapToAggregate(request.orderDTO));
            return order.Adapt<OrderDTO>();
        }

        private OrderService.Core.OrderAggregate.Order MapToAggregate(OrderDTO orderDTO)
        {
            return new OrderService.Core.OrderAggregate.Order(
                new OrderService.Core.OrderAggregate.ValueObjects.Price(orderDTO.PriceEuro.Euro),
                orderDTO.Coupon == null ? null : new OrderService.Core.OrderAggregate.Entities.CouponEntity.Coupon(
                    new OrderService.Core.OrderAggregate.Entities.CouponEntity.ValueObjects.CouponName(orderDTO.Coupon.Name.Name),
                    new OrderService.Core.OrderAggregate.Entities.CouponEntity.ValueObjects.CouponPrice(orderDTO.Coupon.Price.EuroPrice)
                    ),
                new OrderService.Core.OrderAggregate.ValueObjects.UserId(orderDTO.UserId.Id),
                MapItems(orderDTO),
                new OrderService.Core.OrderAggregate.ValueObjects.RestaurantId(orderDTO.RestaurantId.Id)
                );
        }

        private List<OrderService.Core.OrderAggregate.Entities.OrderItemEntity.OrderItem> MapItems(OrderDTO orderDTO)
        {
            var result = new List<OrderService.Core.OrderAggregate.Entities.OrderItemEntity.OrderItem>();

            foreach (var item in orderDTO.Items)
            {
                var orderItem = new OrderService.Core.OrderAggregate.Entities.OrderItemEntity.OrderItem(
                    new OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects.RestaurantItemId(item.RestaurantItemId.ItemId),
                    new OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects.ItemName(item.Name.Name),
                    new OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects.ItemQuantity(item.Quantity.Quantity),
                    new OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects.ItemPrice(item.Price.Price),
                    MapIngredients(item.ExtraIngredients)
                    );
                result.Add(orderItem);
            }

            return result;
        }

        private List<OrderService.Core.OrderAggregate.Entities.IngredientEntity.ExtraIngredient> MapIngredients(List<ExtraIngredientDTO> ingredients)
        {
            var result = new List<OrderService.Core.OrderAggregate.Entities.IngredientEntity.ExtraIngredient>();

            foreach (var item in ingredients)
            {
                var ingredientItem = new OrderService.Core.OrderAggregate.Entities.IngredientEntity.ExtraIngredient(
                    new OrderService.Core.OrderAggregate.Entities.IngredientEntity.ValueObjects.IngredientName(item.Name.Name),
                    new OrderService.Core.OrderAggregate.Entities.IngredientEntity.ValueObjects.IngredientQuantity(item.Quantity.Quantity)
                    );
                result.Add(ingredientItem);
            }

            return result;
        }


    }
}
