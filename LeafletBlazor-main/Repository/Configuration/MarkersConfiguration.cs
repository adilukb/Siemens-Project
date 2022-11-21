using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class MarkersConfiguration : IEntityTypeConfiguration<MarkerProperties>
    {
        public void Configure(EntityTypeBuilder<MarkerProperties> builder)
        {
            builder.HasData
                (
                    new MarkerProperties
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
                    new MarkerProperties
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
                    new MarkerProperties
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
                   new MarkerProperties
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
                   new MarkerProperties
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
                   new MarkerProperties
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
                   new MarkerProperties
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
                   new MarkerProperties
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
                   new MarkerProperties
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
                   new MarkerProperties
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
                   }
                );
        }
    }
}
