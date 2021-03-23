using System;
using System.Globalization;
using System.Threading.Tasks;
using SpaceEngine;
using SpaceEngine.Utils;

namespace SpaceConsole
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // TODO: Separate menu from SpaceORM
            // TODO: Close DB Connections
            // TODO: Add try again option for entering character name
            // TODO: More unit tests
            // TODO: Add more todo's where you see fit
            // TODO: Add a history functionality
            // TODO: You should show your spaceships when you choose to park, not before
            // if you unpark the menu asks what you want to do but you cant park because there is no option to choose a vehicle

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
                else if (selectedOption == 1)
                {
                    Parkingspot.Unpark(starship, character);
                }
                else if (selectedOption == 2)
                {

                }
                else
                {
                    menuGoing = false;
                    Console.WriteLine("Have a nice day!");
                }
            }
        }
    }
}
