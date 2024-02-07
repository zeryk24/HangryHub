using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Contracts.Messages.MessageParts
{
    public record DeliveryDataMessage
    {
        public required string DeliveryLocation { get; set; }
        public required string Note { get; set; }
        public required string UserContact { get; set; }
    }
}
