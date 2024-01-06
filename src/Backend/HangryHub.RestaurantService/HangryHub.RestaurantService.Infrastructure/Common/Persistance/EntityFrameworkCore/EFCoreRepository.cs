﻿using HangryHub.RestaurantService.Application.Common.Persistance;
using HangryHub.RestaurantService.Domain.Common.Attributes;
using Microsoft.EntityFrameworkCore;

namespace HangryHub.RestaurantService.Infrastructure.Common.Persistance.EntityFrameworkCore;

[Register(typeof(IRepository<>))]
public class EFCoreRepository<TAggregate> : IRepository<TAggregate> where TAggregate : class
{
    protected readonly RestaurantServiceDbContext _context;
    protected readonly DbSet<TAggregate> _dbSet;


    public EFCoreRepository(RestaurantServiceDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TAggregate>();
    }

    public async Task<TAggregate> InsertAsync(TAggregate entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task InsertRangeAsync(List<TAggregate> entity) => await _dbSet.AddRangeAsync(entity);

    public void Update(TAggregate entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<bool> RemoveAsync(object id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is null)
            return false;

        _dbSet.Remove(entity);
        return true;
    }

    public async Task CommitAsync() => await _context.SaveChangesAsync();

}

