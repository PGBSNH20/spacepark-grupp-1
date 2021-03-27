using System;
using System.Linq;
using SpaceEngine.Model;
namespace SpaceEngine.Utils
{
    public class Print
    {
        public static void TakenSpots()
        {
            using var context = new SpaceParkContext();
            var parkingsTaken = context.Parkingspots.Where(p => p.SpaceshipName != null);
            Console.WriteLine();
            if (parkingsTaken.Count() == 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (parkingsTaken.Count() <= 2 || parkingsTaken.Count() <= 4)
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

        public static void PrintReceipt(Receipt receipt, int i = 0)
        {
            if (i % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            Console.WriteLine($"Receipt ID: {receipt.ID}\n " +
            $"Character: {receipt.Name}\n " +
            $"Starship: {receipt.StarshipName}\n " +
            $"Parking size: {receipt.Parkingspot.MaxSize}meters\n " +
            $"Arrival: {receipt.Arrival}\n " +
            $"Departure: {receipt.Departure}\n " +
            $"Total Price:{receipt.TotalAmount}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
