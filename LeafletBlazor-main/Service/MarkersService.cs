using Entities;
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
    internal sealed class MarkersService : IMarkersService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger _logger;
        public MarkersService(IRepositoryManager repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;   
        }
        public IEnumerable<MarkerProperties> GetAllMarkers(bool trackChanges)
        {
            try
            {
                var markers = _repository.MarkerProperties.GetAllMarkers(trackChanges);
                return markers;
            }
            catch
            {
                _logger.LogError($"Something went wrong");
            throw;
            }
        }
    }
}
