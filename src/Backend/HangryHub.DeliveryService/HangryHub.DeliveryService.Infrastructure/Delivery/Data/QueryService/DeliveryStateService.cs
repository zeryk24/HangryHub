using HangryHub.DeliveryService.Application.Common;
using HangryHub.DeliveryService.Application.Delivery.Queries.GetState;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Infrastructure.Delivery.Data.QueryService
{
    public class DeliveryStateService : IDeliveryStateService
    {
        IRepository<Domain.DeliveryAggregate.Delivery> _repository;
        public DeliveryStateService(IRepository<Domain.DeliveryAggregate.Delivery> repository) {
            _repository = repository;
        }
        public async Task<DeliveryState> GetState(Guid deliveryID)
        {
            var delivery = await _repository.GetByIdAsync(deliveryID);
            if (delivery == null)
                throw new Exception("Delivery not found"); // TODO: Better exception?
            return delivery.State;
        }

        public async Task<TimeSpan> GetTimeEstimate(Guid deliveryID)
        {
            var delivery = await _repository.GetByIdAsync(deliveryID);
            TimeSpan timeEstimate = TimeSpan.Zero;

            if (delivery == null) return timeEstimate;

            // very smart time estimate algorithm
            // we should pattent this
            if (delivery.State == DeliveryState.NotAsigned)
            {
                timeEstimate = new TimeSpan(0, 30, 0);
            }
            else if (delivery.State == DeliveryState.WaitingForPickup)
            {
                timeEstimate = new TimeSpan(0, 15, 0);
            }
            else if (delivery.State == DeliveryState.OnTheWay)
            {
                timeEstimate = new TimeSpan(0, 10, 0);
            }
            else 
            {
                timeEstimate = TimeSpan.Zero;
            }   

            return timeEstimate;
            
        }
    }
}
