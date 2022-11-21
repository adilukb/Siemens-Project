using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PinPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MarkersRepository :RepositoryBase<MarkerProperties>, IMarkersRepository
    {
        public MarkersRepository
            (
            RepositoryContext repositoryContext,
            ILogger logger
            ) : base(repositoryContext, logger)
        {

        }
        public override async Task<IEnumerable<MarkerProperties>> All()
        {
            try
            {
                return await dbSet.ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(MarkersRepository));
                return new List<MarkerProperties>();

            }
        }
        public override async Task<bool> Upsert(MarkerProperties entity)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(MarkersRepository));
                return false;
            }

        }

        public override async Task<bool> Delete(int Id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == Id)
                                .FirstOrDefaultAsync();

                if (exist != null)
                {
                    dbSet.Remove(exist);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(MarkersRepository));
                return false;
            }
        }
    }
}
