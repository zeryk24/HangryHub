using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Contracts.Messages.MessageParts
{
    public record AdditionalIngredientMessage
    {
        public required Guid AdditionalIngredientId { get; set; }
        public required string Name { get; set; }
        public required int Quantity { get; set; }
    }
}
