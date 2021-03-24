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
            //PATRIC
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-KID3QF2\SQLEXPRESS;Database=SpacePark;Trusted_Connection=Yes;");

            //ANAS
            //optionsBuilder.UseSqlServer(@"Server = DESKTOP-7NBHFKN; Database = CodeFirst; Trusted_Connection = True;");

            //JONAS
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-AI55B02\SQLEXPRESS;Database=SpacePark;Trusted_Connection=Yes;");
        }
    }
}
