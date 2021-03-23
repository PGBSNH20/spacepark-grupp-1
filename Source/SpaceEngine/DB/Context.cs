using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpaceEngine.Model;

namespace SpaceEngine
{
    public class MyContext : DbContext
    {
        //public DbSet<Character> Character { get; set; }
        //public DbSet<Starship> StarShip { get; set; }

        public DbSet<Parkingspot> Parkingspots { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 6; i++)
            {
                modelBuilder.Entity<Parkingspot>().HasData(
                    new Parkingspot() { ID = i, MinSize = 0, MaxSize = 500}
                    );
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Data Source=DESKTOP-AI55B02\SQLEXPRESS;Initial Catalog="test database";Integrated Security=True
            //PATRIC - "Server=DESKTOP-KID3QF2\SQLEXPRESS;Database=SpacePark;Trusted_Connection=Yes;
            //JONAS -  "Server=DESKTOP-AI55B02\SQLEXPRESS;Database=SpacePark;Trusted_Connection=Yes;
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-AI55B02\SQLEXPRESS;Database=SpacePark;Trusted_Connection=Yes;");
        }
    }
}
