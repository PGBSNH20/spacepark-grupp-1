using RestSharp;
using System;
using System.Threading.Tasks;

namespace SpaceEngine
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Traveler, Welcome to SpacePark!\n");
            Console.Write("Enter your name: ");
            string input = Console.ReadLine();
            await SpaceOrm.ValidateCharacter(input);

            bool menuGoing = true;
            Console.WriteLine("Welcome!");
            Console.WriteLine();

            while (menuGoing)
            {
                int selectedOption = Menu.ShowMenu("What do you want to do?\n", new[]
                {
                    "Park Vehicle",
                    "Unpark Vehicle",
                    "Show parking history",
                     "Exit"
                });

                if(selectedOption == 3)
                {
                    menuGoing = false;
                    Console.WriteLine("Have a nice day!");
                }
            }
        }
    }
}
