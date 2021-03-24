using System;
using System.Linq;

namespace SpaceEngine.Utils
{
    public class Print
    {
        public static void TakenSpots()
        {
            var context = new MyContext();
            var parkingsTaken = context.Parkingspots.Where(p => p.SpaceshipName != null);
            Console.WriteLine();
            if (parkingsTaken.Count() == 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (parkingsTaken.Count() <= 2|| parkingsTaken.Count()<=4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"Parkingsspots occupied [{parkingsTaken.Count()}/5]\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
