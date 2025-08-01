﻿namespace Library_Management_System.Infrastructure.Repository;

public interface IRepository<T> where T : class
{
   Task<IEnumerable<T>> GetAllAsync();
    
    Task<T?> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<int> SaveChangesAsync();
    


}
