using Businness.Interfaces;
using Data;
using Data.Models;
using Gridify;
using Microsoft.EntityFrameworkCore;

namespace Businness.Services
{
    public abstract class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly SchoolDbContext _context;
        private bool disposed = false;

        public GenericService(SchoolDbContext context)
        {
            this._context = context;
        }

        public virtual async Task<T> AddAsync(T item)
        {
            _context.Set<T>().Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            Student book = _context.Students.Where(b => b.Id == id).First();
            _context.Students.Remove(book);
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                  
                    _context.Dispose();
                    
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual async Task<ICollection<T>> GetAllAsync(GridifyQuery query)
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            
           return await _context.Set<T>().FindAsync(id);

        }

        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<T> UpdateAsync(T item, object key)
        {
            T obj = await _context.Set<T>().FindAsync(key);
            if (obj != null)
            {
                _context.Entry(obj).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                 
            }
            
           return obj;

        }
    }
}

