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
            Print.TakenSpots();
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;          
            Character character = await Menu.CharacterSelection();
            Starship starship = await Menu.GetStarShips(character);
            Menu.Start(character, starship);
                       
        }
    }
}
// TODO: Separate menu from SpaceORM
// TODO: Close DB Connections
// TODO: Add try again option for entering character name
// TODO: Fix the menu
// TODO: More unit tests
// TODO: Add more todo's where you see fit

