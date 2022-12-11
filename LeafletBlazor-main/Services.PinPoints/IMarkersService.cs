using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PinPoints
{
    public interface IMarkersService
    {
        IEnumerable<MarkerProperties> GetAllMarkers(bool trackChanges);
    }
}
