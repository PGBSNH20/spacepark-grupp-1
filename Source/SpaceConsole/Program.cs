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
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Print.TakenSpots();
            Character character = await Menu.CharacterSelection();
            Starship starship = await Menu.GetStarShips(character);
            Menu.Start(character, starship);
        }
    }
}
