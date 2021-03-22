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

        //public Parkingspot(int id, int minSize, int maxSize)
        //{
        //    ID = id; 
        //    MinSize = minSize;
        //    MaxSize = maxSize;
        //}

        public static void Park(Starship starship, Character character)
        {
            try
            {
                var context = new MyContext();
                var parking = context.Parkingspots
                    .Where(p => p.MinSize < double.Parse(starship.Length)
                    && p.MaxSize > double.Parse(starship.Length)
                    && p.SpaceshipName == null).First();
                parking.SpaceshipName = starship.Name;
                parking.CharacterName = character.Name;
                context.SaveChanges();
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No parkings available");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }
    }
}
