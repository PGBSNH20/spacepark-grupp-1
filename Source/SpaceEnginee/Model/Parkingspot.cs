using SpaceEngine.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpaceEngine.Utils;

namespace SpaceEngine
{
    public class Parkingspot
    {
        [Key]
        public int ID { get; set; }
        public int MinSize { get; set; }
        public int MaxSize { get; set; }
        public string CharacterName { get; set; }
        public string SpaceshipName { get; set; }
        public DateTime Arrival { get; set; }

        public static void Park(Starship starship, Character character)
        {
            var context = new SpaceParkContext();
            // Kontrollera om användaren redan parkerat inmatat skepp.
            Parkingspot alreadyParked = context.Parkingspots.Where(p => p.CharacterName == character.Name && p.SpaceshipName == starship.Name).FirstOrDefault();

            if (alreadyParked == null)
            {
                // Kontrollera om det finns en ledig parkering som rymmer skeppets storlek.
                var parking = context.Parkingspots
                    .Where(p => p.MinSize <= double.Parse(starship.Length)
                    && p.MaxSize >= double.Parse(starship.Length)
                    && p.SpaceshipName == null).FirstOrDefault();
                // Kontrollera hur många platser som är tagna.
                var parkingsTaken = context.Parkingspots.Where(p => p.SpaceshipName != null).Count();
                // Räknar ut totala mängden parkeringsplatser.
                var totalParkings = context.Parkingspots.Count();

                // Om vi hittat en parkering som matchar kriterierna så anger vi nya värden för den parkeringsplatsen och sparar till databasen.
                if (parking != null)
                {
                    parking.SpaceshipName = starship.Name;
                    parking.CharacterName = character.Name;
                    parking.Arrival = DateTime.Now;
                    context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nYour {starship.Name} has been parked at parkingspot number: {parking.ID}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                // Om det finns lediga platser men ingen som matchar användarens skeppstorlek.
                else if (parkingsTaken < totalParkings)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNo parkings available for that size");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No parkings available");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have already parked that Starship");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }

        public static void Unpark(Starship starship, Character character)
        {
            var context = new SpaceParkContext();
            // Hämtar in den parkeringen användaren har parkerat sitt skepp på.
            Parkingspot parked = context.Parkingspots.Where(p => p.CharacterName == character.Name && p.SpaceshipName == starship.Name).FirstOrDefault();
            //Om vi hittat en parking som matchat kriterierna för användaren så.
            if (parked != null)
            {
                // Beräkna pris baserat på ankomst och avgångs tider.
                DateTime Departure = DateTime.Now;
                double diff2 = (Departure - parked.Arrival).TotalMinutes;
                double price = Math.Round(diff2, 0, MidpointRounding.AwayFromZero) * 200;
                Console.Clear();
                // Skapa nytt kvitto
                Receipt receipt = new ()
                {
                    StarshipName = starship.Name,
                    Name = character.Name,
                    Arrival = parked.Arrival,
                    Departure = Departure,
                    Parkingspot = parked,
                    TotalAmount = price
                };
                // Lägg till kvitto till databasen, ändra värden på parkeringsplatsen och spara ändringar.
                context.Receipts.Add(receipt);
                parked.CharacterName = null;
                parked.SpaceshipName = null;
                parked.Arrival = default;
                context.SaveChanges();
                Console.WriteLine($"You have successfully unparked your vehicle {starship.Name}\n");
                Print.PrintReceipt(receipt);
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(starship.Name + " is not parked in our SpacePark!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }

        public static void ShowHistory(Character character)
        {
            using var context = new SpaceParkContext();
            // Hämta alla kvitton där användaren förekommer baserat på namn.
            var characterReceipts = context.Receipts.Where(p => p.Name == character.Name).Include("Parkingspot").ToList();
            Console.WriteLine($"\n{character.Name}'s parking history");
            Console.WriteLine();
            for (int i = 0; i < characterReceipts.Count; i++)
            {
                Print.PrintReceipt(characterReceipts[i], i);
            }
        }
    }
}
