using RestSharp;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using SpaceEngine.Utils;

namespace SpaceEngine
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            bool menuGoing = true;

            Print.AvailableSpots();
            
            Character character = await SpaceORM.CharacterSelection();
            Starship starship = await SpaceORM.GetStarShips(character);
            while (menuGoing)
            {
                int selectedOption = Menu.ShowMenu($"What do you want to do {character.Name}?\n", new[]
                {
                    "Park Vehicle",
                    "Unpark Vehicle",
                    "Show parking history",
                     "Exit"
                });
                if (selectedOption == 0)
                {
                    Parkingspot.Park(starship, character);
                }
                if (selectedOption == 3)
                {
                    menuGoing = false;
                    Console.WriteLine("Have a nice day!");
                }
            }
        }
    }
}
