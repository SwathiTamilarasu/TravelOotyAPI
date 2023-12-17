﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Contracts.Persistance
{
    public interface IAsyncRespository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByGuIdAsync(Guid guid);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
       Task UpdatePropertyAsync(Property property);
        Task SaveChanges();
    }
}
 