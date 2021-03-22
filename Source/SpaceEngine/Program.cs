using RestSharp;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceEngine
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            bool menuGoing = true;
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

                if (selectedOption == 3)
                {
                    menuGoing = false;
                    Console.WriteLine("Have a nice day!");
                }
            }
        }
    }
}
