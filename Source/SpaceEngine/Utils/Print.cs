using System;
using System.Linq;

namespace SpaceEngine.Utils
{
    public class Print
    {
        public static void AvailableSpots()
        {
            var context = new MyContext();
            var parkingsAvailable = context.Parkingspots.Where(p => p.SpaceshipName != null);
            Console.WriteLine();
            if (parkingsAvailable.Count() == 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"Parkingsspots occupied [{parkingsAvailable.Count()}/5]\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
