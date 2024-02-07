﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Repository
{
    public interface IRepository<TAggregate> where TAggregate : class
    {
        Task<TAggregate?> GetByIdAsync(object id);

        void Insert(TAggregate entity);

        Task<bool> RemoveAsync(object id);

        void Update(TAggregate entity);

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
