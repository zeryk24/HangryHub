using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Domain.Common
{
    public abstract class AggregateRoot
    {
        public Guid Id { get; set; }

        public AggregateRoot(Guid id)
        {
            Id = id;
        }
    }
}
