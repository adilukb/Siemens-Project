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

<<<<<<< HEAD
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
=======
        /*        public static class DbInitializer
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
                            new MarkerViewModel { Id = 1, Keyboard = default, Title = "Xyz", Alt = default, ZIndexOffset = default, Opacity = default, RiseOnHover = default, RiseOffset = default, Latitude = 22, Longitude = 44},
                            new MarkerViewModel { Id = 2, Keyboard = default, Title = "Yxz", Alt = default, ZIndexOffset = default, Opacity = default, RiseOnHover = default, RiseOffset = default, Latitude = 23, Longitude = 43 },
                            new MarkerViewModel { Id = 3, Keyboard = default, Title = "Zyx", Alt = default, ZIndexOffset = default, Opacity = default, RiseOnHover = default, RiseOffset = default, Latitude = 24, Longitude = 42 }
                        };

                        foreach (MarkerViewModel m in markers)
                        {
                            context.Markers.Add(m);
                        }
                        context.SaveChanges();
                    }
                }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
>>>>>>> d5b02d53c37ba059de2899a3b7068b9fb28fe707
        {
            modelBuilder.Entity<MarkerViewModel>().HasData(
                    new MarkerViewModel
                    {
                        Id = 1,
                        Keyboard = default,
                        Title = "Arieșeni",
                        Alt = default,
                        ZIndexOffset = default,
                        Opacity = default,
                        RiseOnHover = default,
                        RiseOffset = default,
                        Latitude = 46.4768747,
                        Longitude = 22.7541473
                    },
                    new MarkerViewModel
                    {
                        Id = 2,
                        Keyboard = default,
                        Title = "Azuga",
                        Alt = default,
                        ZIndexOffset = default,
                        Opacity = default,
                        RiseOnHover = default,
                        RiseOffset = default,
                        Latitude = 45.44273707,
                        Longitude = 25.58889896
                    },
                    new MarkerViewModel
                    {
                        Id = 3,
                        Keyboard = default,
                        Title = "Baia Sprie",
                        Alt = default,
                        ZIndexOffset = default,
                        Opacity = default,
                        RiseOnHover = default,
                        RiseOffset = default,
                        Latitude = 47.661522,
                        Longitude = 23.6956528
                    },
                   new MarkerViewModel
                   {
                       Id = 4,
                       Keyboard = default,
                       Title = "Băile Homorod",
                       Alt = default,
                       ZIndexOffset = default,
                       Opacity = default,
                       RiseOnHover = default,
                       RiseOffset = default,
                       Latitude = 46.3502813,
                       Longitude = 25.4733735
                   },
                   new MarkerViewModel
                   {
                       Id = 5,
                       Keyboard = default,
                       Title = "Băile Tușnad",
                       Alt = default,
                       ZIndexOffset = default,
                       Opacity = default,
                       RiseOnHover = default,
                       RiseOffset = default,
                       Latitude = 46.1556322,
                       Longitude = 25.8707339
                   },
                   new MarkerViewModel
                   {
                       Id = 6,
                       Keyboard = default,
                       Title = "Băișoara",
                       Alt = default,
                       ZIndexOffset = default,
                       Opacity = default,
                       RiseOnHover = default,
                       RiseOffset = default,
                       Latitude = 46.5359435,
                       Longitude = 23.3098931
                   },
                   new MarkerViewModel
                   {
                       Id = 7,
                       Keyboard = default,
                       Title = "Bâlea",
                       Alt = default,
                       ZIndexOffset = default,
                       Opacity = default,
                       RiseOnHover = default,
                       RiseOffset = default,
                       Latitude = 45.6047439,
                       Longitude = 24.6171756
                   },
                   new MarkerViewModel
                   {
                       Id = 8,
                       Keyboard = default,
                       Title = "Borșa",
                       Alt = default,
                       ZIndexOffset = default,
                       Opacity = default,
                       RiseOnHover = default,
                       RiseOffset = default,
                       Latitude = 47.6308945,
                       Longitude = 24.7407681
                   },
                   new MarkerViewModel
                   {
                       Id = 9,
                       Keyboard = default,
                       Title = "Borsec",
                       Alt = default,
                       ZIndexOffset = default,
                       Opacity = default,
                       RiseOnHover = default,
                       RiseOffset = default,
                       Latitude = 46.9782008,
                       Longitude = 25.5768737
                   },
                   new MarkerViewModel
                   {
                       Id = 10,
                       Keyboard = default,
                       Title = "Bran",
                       Alt = default,
                       ZIndexOffset = default,
                       Opacity = default,
                       RiseOnHover = default,
                       RiseOffset = default,
                       Latitude = 45.5063162,
                       Longitude = 25.3771276
                   });
<<<<<<< HEAD
        }*/
=======
        }
>>>>>>> d5b02d53c37ba059de2899a3b7068b9fb28fe707
    }
}

