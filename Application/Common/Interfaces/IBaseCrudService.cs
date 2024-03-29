﻿using Domain.Bases;

namespace Application.Common.Interfaces
{
    public interface IBaseCrudService<TEntity> where TEntity : class, IBase
    {
        IQueryable<TEntity> Query();
        Task<TEntity> Get(int id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int id);
    }
}
