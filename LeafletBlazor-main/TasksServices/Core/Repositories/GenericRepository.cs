using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksServices.Model;

namespace TasksServices.Interface.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ServerData _context;

        protected DbSet<T> dbSet;

        protected readonly ILogger _logger;

        //injection
        public GenericRepository(
            ServerData context,
            ILogger logger
            )
        {
            _context = context;
            _logger = logger;
            this.dbSet = context.Set<T>();

        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int Id)
        {
            return await dbSet.FindAsync(Id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }

}
