using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort
{
    class SpaceParkContext: DbContext
    {
        public DbSet<PersonDb> Person { get; set; }
        public DbSet<StarshipData> Starship { get; set; }
       // public DbSet<> Occupancy { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-7NBHFKN; Database = CodeFirst; Trusted_Connection = True;");
            
        }
    }
}
