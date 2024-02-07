﻿using HangryHub.MainService.Domain.ShoppingCartAggregate;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Repository
{
    public interface IShoppingCartAggregateRepository : IRepository<ShoppingCart>
    {
        public Task<IEnumerable<ShoppingCart>> GetAllWithDetailsAsync();

        public Task<IEnumerable<ShoppingCart>> GetWithDetailsAsync(params ShoppingCartId[] ids);

        public Task<ShoppingCart?> GetWithDetailsAsync(ShoppingCartId id);
    }
}
