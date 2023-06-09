﻿namespace BankingSystem.DAL
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByID(object id);

        Task<IEnumerable<TEntity>> GetAll();
    }
}
