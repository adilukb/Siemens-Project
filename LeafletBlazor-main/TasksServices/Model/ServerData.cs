using Microsoft.EntityFrameworkCore;
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
        public DbSet<MarkerViewModel> Markers { get; set; }


    }
}


 