using Microsoft.EntityFrameworkCore;zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TasksServices.Model
{
    public class ServerData : DbContext
    {
        public ServerData(DbContextOptions<ServerData> options) : base(options)
        {
            {

            }
        }
        public DbSet<MarkerViewModel> Id { get; set; }
        public DbSet<MarkerViewModel> Title { get; set; }
        public DbSet<MarkerViewModel> Latitude { get; set; }
        public DbSet<MarkerViewModel> Longitude { get; set; }


    }
}


 