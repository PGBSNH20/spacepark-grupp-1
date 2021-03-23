using SpaceEngine.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            var context = new MyContext();
            Parkingspot alreadyParked;
            alreadyParked = context.Parkingspots.Where(p => p.CharacterName == character.Name && p.SpaceshipName == starship.Name).FirstOrDefault();
            if (alreadyParked == null)
            {

                var parking = context.Parkingspots
                    .Where(p => p.MinSize < double.Parse(starship.Length)
                    && p.MaxSize > double.Parse(starship.Length)
                    && p.SpaceshipName == null).FirstOrDefault();
                if (parking != null)
                {
                    parking.SpaceshipName = starship.Name;
                    parking.CharacterName = character.Name;
                    parking.Arrival = DateTime.Now;
                    context.SaveChanges();
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
            var context = new MyContext();
            Parkingspot parked;
            parked = context.Parkingspots.Where(p => p.CharacterName == character.Name && p.SpaceshipName == starship.Name).FirstOrDefault();
            if (parked != null)
            {
                DateTime Departure;
                Departure = DateTime.Now;
                double diff2 = (Departure - parked.Arrival).TotalMinutes;
                double price = Math.Round(diff2, 0, MidpointRounding.AwayFromZero) * 200;
                Console.Clear();
                Console.WriteLine($"\nTotal cost for the parking: {price}\n");

                Receipt receipt = new Receipt
                {
                    StarshipName = starship.Name,
                    Name = character.Name,
                    Arrival = parked.Arrival,
                    Departure = Departure,
                    Parkingspot = parked,
                    TotalAmount = price
                };
                context.Receipts.Add(receipt);
                parked.CharacterName = null;
                parked.SpaceshipName = null;
                parked.Arrival = default;
                context.SaveChanges();
                Console.WriteLine("You have successfully unparked your vehicle");
            }
        }

        public static void ShowHistory()
        {
            using var context = new MyContext();
            var allReceipts = context.Receipts.Include("Parkingspot").ToList();
            Console.WriteLine("SpacePark parking history");
            Console.WriteLine();
            for (int i = 0; i < allReceipts.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine($"ID: {allReceipts[i].ID}\n Character: {allReceipts[i].Name}\n Starship: {allReceipts[i].StarshipName}\n Parking size: {allReceipts[i].Parkingspot.MaxSize}meters\n Arrival: {allReceipts[i].Arrival}\n Departure: {allReceipts[i].Departure}\n Total Price:{allReceipts[i].TotalAmount}\n");
            }
                Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
