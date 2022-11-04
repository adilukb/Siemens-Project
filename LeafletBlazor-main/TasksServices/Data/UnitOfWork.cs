using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksServices.Interface;
using TasksServices.Interface.IConfiguration;
using TasksServices.Interface.Repositories;
using TasksServices.Model;
using TasksServices.Repository;

namespace TasksServices.Data
{
    public class UnitOfWork :IUnitOfWork, IDisposable
    {
        private readonly ServerData _context;

        private readonly ILogger _logger;
        
        public IDataRepository Markers { get; private set; }
        
        public UnitOfWork(
            ServerData context,
            ILoggerFactory loggerFactory
            )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Markers = new DataRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
