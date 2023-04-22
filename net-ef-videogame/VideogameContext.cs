using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal class VideogameContext : DbContext
    {
        public DbSet<Videogame> Videogame { get; set; }
        public DbSet<SoftwareHouse> SoftwareHouse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=net-ef-videogame;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
