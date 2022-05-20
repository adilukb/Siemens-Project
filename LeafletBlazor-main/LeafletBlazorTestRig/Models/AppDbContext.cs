using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafletBlazorTestRig.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options)
            : base(options)
        {

        }
        
        public DbSet<MarkerData> MarkerDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MarkerData>().HasData(new MarkerData
            {
                MarkerId = 1,
                MarkerLatitude = 23,
                MarkerLongitude = 32,
                MarkerKeyboard = true,
                MarkerAlt = "Marker1",
                MarkerZIndexOffset = 250,
                MarkerOpacity = 250,
                MarkerRiseOnHover = true,
                MarkerRiseOffset = 250

            });
            modelBuilder.Entity<MarkerData>().HasData(new MarkerData
            {
                MarkerId = 2,
                MarkerLatitude = 44,
                MarkerLongitude = 23,
                MarkerKeyboard = true,
                MarkerAlt = "Marker2",
                MarkerZIndexOffset = 250,
                MarkerOpacity = 250,
                MarkerRiseOnHover = true,
                MarkerRiseOffset = 250

            });
            modelBuilder.Entity<MarkerData>().HasData(new MarkerData
            {
                MarkerId = 3,
                MarkerLatitude = 32,
                MarkerLongitude = 54,
                MarkerKeyboard = true,
                MarkerAlt = "Marker3",
                MarkerZIndexOffset = 250,
                MarkerOpacity = 250,
                MarkerRiseOnHover = true,
                MarkerRiseOffset = 250

            });
            modelBuilder.Entity<MarkerData>().HasData(new MarkerData
            {
                MarkerId = 4,
                MarkerLatitude = 2,
                MarkerLongitude = 31,
                MarkerKeyboard = true,
                MarkerAlt = "Marker4",
                MarkerZIndexOffset = 250,
                MarkerOpacity = 250,
                MarkerRiseOnHover = true,
                MarkerRiseOffset = 250

            });
        }

    }
}
