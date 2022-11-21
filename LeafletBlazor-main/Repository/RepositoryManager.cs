using Microsoft.Extensions.Logging;
using PinPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager, IDisposable
    {
        private readonly RepositoryContext _repositoryContext;

        private readonly ILogger _logger;

        public IMarkersRepository Markers { get; private set; }

        public RepositoryManager
            (RepositoryContext repositoryContext,
            ILoggerFactory loggerFactory
            )
        {
            _repositoryContext = repositoryContext;
            _logger = loggerFactory.CreateLogger("logs");

            Markers = new MarkersRepository(_repositoryContext, _logger);
               // new MarkersRepository(repositoryContext));
        }
        public async Task CompleteAsync()
        {
            await _repositoryContext.SaveChangesAsync();

        }

        public void Dispose()
        {
            _repositoryContext.Dispose();
        }

        /*public IMarkersRepository MarkerProperties => _markersRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();*/

    }
}
