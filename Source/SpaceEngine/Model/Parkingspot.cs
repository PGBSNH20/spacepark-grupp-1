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
}
