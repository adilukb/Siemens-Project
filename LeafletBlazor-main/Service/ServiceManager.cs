using Microsoft.Extensions.Logging;
using PinPoints;
using Services.PinPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMarkersService> _markersService;
        public ServiceManager(IRepositoryManager repositoryManager, ILogger
        logger)
        {
            _markersService = new Lazy<IMarkersService>(() => new
            MarkersService(repositoryManager, logger));
        }
        public IMarkersService MarkersService => _markersService.Value;
    }
}
