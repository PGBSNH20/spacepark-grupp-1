using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            using (var context = new SpaceParkContext())
            {
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
            
        }

        public static void Unpark(Starship starship, Character character)
        {
            using (var context = new SpaceParkContext())
            {
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

                    parked.CharacterName = null;
                    parked.SpaceshipName = null;
                    parked.Arrival = default;
                    context.SaveChanges();
                    Console.WriteLine("You have successfully unparked your vehicle");
                }
            }
        }
    }
}
