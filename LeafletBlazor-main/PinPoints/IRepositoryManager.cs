using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinPoints
{
    public interface IRepositoryManager
    {
        IMarkersRepository Markers { get; }

        Task CompleteAsync();

    }
}
