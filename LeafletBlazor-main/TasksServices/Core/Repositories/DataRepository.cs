using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TasksServices.Model;

namespace TasksServices.Interface.Repositories
{
    public class DataRepository : GenericRepository<MarkerViewModel>, IDataRepository
    {
        public DataRepository(
            ServerData context,
            ILogger logger
            ) : base(context, logger)
            {
                
            }
        public override async Task<IEnumerable<MarkerViewModel>> All()
        {
            try
            {
                return await dbSet.ToListAsync();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(DataRepository));
                return new List<MarkerViewModel>();

            }
        }
        public override async Task<bool> Upsert(MarkerViewModel entity)
        {
            try
            {
                var existingData = await dbSet.Where(x => x.Id == entity.Id)
                                           .FirstOrDefaultAsync();
                if (existingData == null)
                {
                    return await Add(entity);
                }
                else
                {
                    existingData.Keyboard = entity.Keyboard;
                    existingData.Title = entity.Title;
                    existingData.Alt = entity.Alt;
                    existingData.ZIndexOffset = entity.ZIndexOffset;
                    existingData.Opacity = entity.Opacity;
                    existingData.RiseOnHover = entity.RiseOnHover;
                    existingData.RiseOffset = entity.RiseOffset;
                    existingData.Latitude = entity.Latitude;
                    existingData.Longitude = entity.Longitude;
                }

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(DataRepository));
                return false;
            }
            
        }

        public override async Task<bool> Delete(int Id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == Id)
                                .FirstOrDefaultAsync();

                if(exist != null)
                {
                    dbSet.Remove(exist);
                    return true;
                }
                return false;

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(DataRepository));
                return false;
            }
        }
    }
}
