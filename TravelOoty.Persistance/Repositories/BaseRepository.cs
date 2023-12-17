using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Persistance.Repositories
{
    public class BaseRepository<T>:IAsyncRespository<T> where T:class
    {
        protected readonly TravelOotyDbContext _dbContext;
        public BaseRepository(TravelOotyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
       
        public virtual async Task<T> GetByGuIdAsync(Guid guid)
        {
            return await _dbContext.Set<T>().FindAsync(guid);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            try
            {
              if(_dbContext.Entry(entity).State!=EntityState.Detached)
                  {                    
                    _dbContext.Entry(entity).State = EntityState.Modified;
                   }
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                //_dbContext.Entry(entity).State = EntityState.Detached;
                //await _dbContext.SaveChangesAsync();
            }
        }
        public async Task UpdatePropertyAsync(Property property)
        {
            try
            {
                if (_dbContext.Entry(property).State != EntityState.Detached)
                {
                    _dbContext.Entry(property).Property(e => e.ImageName).IsModified = false;
                    _dbContext.Entry(property).Property(e => e.ImagePath).IsModified = false;
                    _dbContext.Entry(property).State = EntityState.Modified;
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //_dbContext.Entry(entity).State = EntityState.Detached;
                //await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            try
            {

                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
