using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PinPoints
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> All();

        Task<T> GetById(int Id);

        Task<bool> Add(T entity);

        Task<bool> Delete(int Id);

        Task<bool> Upsert(T entity);
    }
}
