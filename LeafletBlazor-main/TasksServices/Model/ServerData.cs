using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TasksServices.Model
{
    public class ServerData : DbContext
    {
        public ServerData(DbContextOptions<ServerData> options) : base(options)
        {
            {

            }
        }
        public DbSet<MarkerViewModel> Markers { get; set; }

        public static class DbInitializer
        {
            public static void Initialize(ServerData context)
            {
                context.Database.EnsureCreated();

                // Look for any students.
                if (context.Markers.Any())
                {
                    return;   // DB has been seeded
                }

                var markers = new MarkerViewModel[]
                {
                    new MarkerViewModel { Title = "X", Longitude = 44, Latitude = 22 },
                    new MarkerViewModel { Title = "Y", Longitude = 43, Latitude = 23 },
                    new MarkerViewModel { Title = "Z", Longitude = 44, Latitude = 24 }
                };

                foreach (MarkerViewModel m in markers)
                {
                    context.Markers.Add(m);
                }
                context.SaveChanges();
            }
        }
    }
}

