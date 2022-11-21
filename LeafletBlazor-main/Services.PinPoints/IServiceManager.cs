using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PinPoints
{
    public interface IServiceManager
    {
        IMarkersService MarkersService { get; }
    }
}
