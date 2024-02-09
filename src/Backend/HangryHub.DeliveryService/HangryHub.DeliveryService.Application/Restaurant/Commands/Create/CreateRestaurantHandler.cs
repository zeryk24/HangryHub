using HangryHub.DeliveryService.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Restaurant.Commands.Create
{
    public class CreateRestaurantHandler : IRequestHandler<CreateRestaurantCommand>
    {
        private IRepository<Domain.RestaurantAggregate.Restaurant> _repository;
        public CreateRestaurantHandler(IRepository<Domain.RestaurantAggregate.Restaurant> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {

            var restaurent = new Domain.RestaurantAggregate.Restaurant(
                request.Restaurant.RestaurantId,
                request.Restaurant.RestaurantName,
                request.Restaurant.Contact,
                request.Restaurant.Address

            );
            var db_restaurant = await _repository.GetByIdAsync(restaurent.Id);
            if (db_restaurant  != null)
            {
                _repository.Update(restaurent);
            }
            else
            {
                _repository.Insert(restaurent);
            }
            _repository.SaveChanges();
           
        }
    }
}
