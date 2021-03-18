using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpaceEngine
{
    public class MyContext : DbContext
    {
        public DbSet<Character> Character { get; set; }
        public DbSet<Starship> StarShip { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Data Source=DESKTOP-AI55B02\SQLEXPRESS;Initial Catalog="test database";Integrated Security=True
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-AI55B02\SQLEXPRESS;Database=SpacePark;Trusted_Connection=Yes;");
        }
    }
}
