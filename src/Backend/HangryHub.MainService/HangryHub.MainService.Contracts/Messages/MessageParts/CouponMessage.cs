﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Contracts.Messages.MessageParts
{
    public record CouponMessage
    {
        public required Guid CouponId { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
    }
}
