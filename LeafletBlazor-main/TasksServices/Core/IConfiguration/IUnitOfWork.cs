using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksServices.Interface.IConfiguration
{
    public interface IUnitOfWork
    {
        IDataRepository Markers { get; }

        Task CompleteAsync();

    }
}
