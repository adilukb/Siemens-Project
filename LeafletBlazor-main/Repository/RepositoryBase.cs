
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PinPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext;

        protected DbSet<T> dbSet;

        protected readonly ILogger _logger;

        public RepositoryBase
            (
            RepositoryContext repositoryContext,
            ILogger logger
            )
        {
            _repositoryContext = repositoryContext;
            _logger = logger;
            this.dbSet = repositoryContext.Set<T>();
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
