using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksServices.Model;

namespace TasksServices.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();

        Task<T> GetById(int Id);

        Task<bool> Add(T entity);

        Task<bool> Delete(int Id);

        Task<bool> Upsert(T entity);


    }
}
